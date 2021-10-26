using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool racePanding = false;
    public static int totalLap = 1;
    public int timer = 5;
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
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating(nameof(CountDown), 3, 1);
    }
}
