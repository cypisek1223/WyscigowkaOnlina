using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;


public class RaceController : MonoBehaviourPunCallbacks
{
    #region RaceFields
    public static bool racePanding = false;
    public static int totalLap = 1;
    public int timer = 5;

    ChackpointController [] cars;



    public Text startText;
    private AudioSource audioSource;
    public AudioClip count;
    public AudioClip start;


    public GameObject endPanel;

    public GameObject carPrefab;
    public Transform[] SpawnPosition;
    public int playerCount;
    #endregion
    #region Photon Logic
    public GameObject StartBurtton;
    public GameObject WaitText;
    [PunRPC]
    public void StartGame()
    {
        WaitText.SetActive(false);
        StartBurtton.SetActive(false);

        InvokeRepeating(nameof(CountDown), 3, 1);

        GameObject[] carObject = GameObject.FindGameObjectsWithTag("Car");
        cars = new ChackpointController[carObject.Length];

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i] = carObject[i].GetComponent<ChackpointController>();
        }

    }

    public void BeginGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC(nameof(StartGame),RpcTarget.All,null);
        }
    }
    #endregion
    void Awake()
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        endPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        startText.gameObject.SetActive(false);

        StartBurtton.SetActive(false);
        WaitText.SetActive(false);

        int randStarPos = UnityEngine.Random.Range(0, SpawnPosition.Length);
        Vector3 startPos = SpawnPosition[randStarPos].position;
        Quaternion starRot = SpawnPosition[randStarPos].rotation;
        GameObject playerCar = null;

        if (PhotonNetwork.IsConnected)
        {
            startPos = SpawnPosition[playerCount - 1].position;
            starRot = SpawnPosition[playerCount - 1].rotation;

            object[] instanceData = new object[4];
            instanceData[0] = PlayerPrefs.GetString("PlayerName");
            instanceData[1] = PlayerPrefs.GetInt("red");
            instanceData[2] = PlayerPrefs.GetInt("green");
            instanceData[3] = PlayerPrefs.GetInt("blue");


            if (OnlinePlayer.LocalPlayer==null)
            {
                playerCar = PhotonNetwork.Instantiate(carPrefab.name,startPos, starRot,0,instanceData);
                playerCar.GetComponent<CarApperence>().SetLocalPlayer();
            }

            if (PhotonNetwork.IsMasterClient)
            {
                StartBurtton.SetActive(true);
            }
            else
            {
                StartBurtton.SetActive(false);
            }
        }


        playerCar.GetComponent<PlayerController>().enabled = true;


      

    }
   void CountDown()
    {
        startText.gameObject.SetActive(true);

        if(timer != 0)
        {
            timer--;
            startText.text = timer.ToString();
            audioSource.PlayOneShot(count);
        }
        else
        {
            startText.text = "Start";
            audioSource.PlayOneShot(start);
            print("Start");
            racePanding = true;
            CancelInvoke(nameof(CountDown));


            Invoke(nameof(HideStartText), 1);
        }
    }

    public void HideStartText()
    {
        startText.gameObject.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void LateUpdate()
    {
        if (cars == null)
            return;

        int finishers = 0;
        foreach(ChackpointController c in cars)
        {
            if(c.lap==totalLap + 1)
            {
                finishers++;
            }
            if(finishers>= cars.Length && racePanding)
            {
                
                racePanding = false;
                endPanel.SetActive(true);
            }
        }
    }
}
