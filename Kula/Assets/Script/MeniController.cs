using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MeniController : MonoBehaviourPunCallbacks
{

    #region Unity Fields region

    public Renderer CarRenderer;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    #endregion
    #region Photon Fields
    public Text NetworkText;
    int maxPlayers = 4;
    bool isConnecting;




    #endregion
    #region Photon Callbacks

    public void Connect()
    {
        NetworkText.text = "";
        isConnecting = true;
        PhotonNetwork.NickName = playerName.text;
        if (PhotonNetwork.IsConnected)
        {
            NetworkText.text += "Joining room....\n";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            NetworkText.text += "Connecting\n";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            NetworkText.text += "Connected to master";
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode,string message)
    {
        NetworkText.text += "Failed to Join Room\n";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = (byte)maxPlayers });
    }
    public override void OnJoinedRoom()
    {
        NetworkText.text += "Joined Roomwith" 
            + PhotonNetwork.CurrentRoom.PlayerCount
            +"players\n";

        PhotonNetwork.LoadLevel("MeinScen");
    }


    #endregion



    #region Menu Script region
    public void JoinRoom()
    {
        SceneManager.LoadScene(0);
    }
    public InputField playerName;

    public void SetName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }
    public static Color IntToColor(int red,int green,int blue)
    {
        float r = (float)red / 255;
        float g = (float)green /255;
        float b = (float)blue /255 ;

            return new Color(r, g, b);
       
    }
    void SetCarColor(int red, int green, int blue)
    {
        Color color = IntToColor(red, green, blue);
        CarRenderer.material.color = color;
        PlayerPrefs.SetInt("red", red);
        PlayerPrefs.SetInt("green",green);
        PlayerPrefs.SetInt("blue",blue);
    }
    // Start is called before the first frame update
    void Awake()
    {

        PhotonNetwork.AutomaticallySyncScene = true;


        playerName.text = PlayerPrefs.GetString("PlayerName");
        redSlider.value= PlayerPrefs.GetInt("red");
        greenSlider.value = PlayerPrefs.GetInt("green");
        blueSlider.value = PlayerPrefs.GetInt("blue");



    }

    // Update is called once per frame
    void Update()
    {
        SetCarColor((int)redSlider.value, (int)greenSlider.value, (int)blueSlider.value);
    }
    #endregion
}
