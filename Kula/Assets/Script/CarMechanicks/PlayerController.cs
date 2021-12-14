using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScripts ds;
    float lastTimeOK = 0;
    // Start is called before the first frame update
    void Start()
    {
        ds = GetComponent<DrivingScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float streer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        ChackpointController checkpointController = ds.rb.GetComponent<ChackpointController>();

        if ((ds.rb.velocity.magnitude > 1 || RaceController.racePanding == false ) || (ds.rb.velocity.magnitude < 1 && accel == 0))
        {
            lastTimeOK = Time.time;
        }
        if (lastTimeOK + 4 < Time.time)
        {
            ds.rb.transform.position = checkpointController.lastPoint.transform.position;
            ds.rb.transform.rotation = checkpointController.lastPoint.transform.rotation;
        }
        //Warstwy

        if (!RaceController.racePanding)
        {
            accel = 0;
        }
        ds.Drive(accel, brake, streer);
    }
}
