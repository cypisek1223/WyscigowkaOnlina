using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
   public float speed;
    public float jump;
    public bool Ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       Ground=false;
}

    // Update is called once per frame
    void Update()
    {
        float MoveHoriznotal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 Move =new Vector3(MoveHoriznotal,0, MoveVertical);
        
        rb.AddForce(Move * Time.fixedDeltaTime*speed);
        if (Input.GetKeyDown(KeyCode.Space)&&Ground)
        {
            Debug.LogError("kliknieto Spacje");
            rb.AddForce(Vector3.up * Time.deltaTime*jump);

        }
    }

 
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ground")
        {
            Ground = true;
            Debug.LogError("na ziemi");
        }
        else
        {
            Ground = false;
            Debug.LogError("w powietrzu ");
        }
    }
    public void Obracanie(float predkoscObracania)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //rb.rotation = new Quaternion(rb.rotation.x,rb.rotation.y,rb.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
