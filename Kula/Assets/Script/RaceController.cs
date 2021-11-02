using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool racePanding = false;
    public static int totalLap = 1;
    public int timer = 5;

    ChackpointController [] cars;
    void Start()
    {
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
        if(timer != 0)
        {
            timer--;
            print("Rozpoczęcie wyścigu za :"+timer);
        }
        else
        {
            print("Start");
            racePanding = true;
            CancelInvoke(nameof(CountDown));
        }
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
                print("Race Finished");
                racePanding = false;
            }
        }
    }
}
