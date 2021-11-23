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
        nameText.text = PlayerName;
        carRenderer.material.color = carColor;
        nameText.color = carColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
