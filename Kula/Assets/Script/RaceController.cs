using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceController : MonoBehaviour
{
    public static bool racePanding = false;
    public static int totalLap = 1;
    public int timer = 5;

    ChackpointController [] cars;



    public Text startText;
    private AudioSource audioSource;
    public AudioClip count;
    public AudioClip start;


    public GameObject endPanel;
    void Start()
    {
        endPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        startText.gameObject.SetActive(false);

        InvokeRepeating(nameof(CountDown), 3, 1);
       
        GameObject[] carObject = GameObject.FindGameObjectsWithTag("Car");
        cars = new ChackpointController[carObject.Length];

        for(int i=0; i < cars.Length; i++)
        {
            cars[i]= carObject[i].GetComponent<ChackpointController>();
        }


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
