using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarApperence : MonoBehaviour
{
    public string PlayerName;
    public Color carColor;

    public Text nameText;
    public Renderer carRenderer;

    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        //if(playerNumber == 0)
        //{
        //    PlayerName = PlayerPrefs.GetString("PlayerName");
        //    carColor = MeniController.IntToColor(PlayerPrefs.GetInt("red"), 
        //                                         PlayerPrefs.GetInt("green"), 
        //                                         PlayerPrefs.GetInt("blue"));
        //}
        //else
        //{
        //    PlayerName = "Random" + playerNumber;
        //    float r = 
        //        Random.Range(0, 1);
        //    carColor = new Color(r, r, r);
        //}
        //nameText.text = PlayerName;
        //carRenderer.material.color = carColor;
        //nameText.color = carColor;


    }
    void SetNameAndColor(string name,Color color)
    {
        nameText.text = name;
        carRenderer.material.color = color;
        nameText.color = color;
    }
    public void SetLocalPlayer()
    {
        FindObjectOfType<CameraController>().SetCamera(this.gameObject);
        PlayerName = PlayerPrefs.GetString("PlayerName");
        carColor = MeniController.IntToColor(PlayerPrefs.GetInt("red"), PlayerPrefs.GetInt("green"), PlayerPrefs.GetInt("blue"));
        SetNameAndColor(PlayerName,carColor);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
