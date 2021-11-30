using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniController : MonoBehaviour
{

    public Renderer CarRenderer;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;



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
    void Start()
    {
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
}
