using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackpointController : MonoBehaviour
{

    public int lap = 0;
    public int Lastchackpoint = -1;
    int CheckPointCount;

    int NextCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        CheckPointCount = GameObject.FindGameObjectsWithTag("ChackPoint").Length;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ChackPoint"))
        {
            int currentCheckpoint = int.Parse(other.gameObject.name);
            if (currentCheckpoint == NextCheckPoint)
            {
                Lastchackpoint++;
                if (Lastchackpoint == 0)
                {
                    lap++;
                    print($"Lap: {lap}");
                }
                NextCheckPoint++;
                NextCheckPoint = NextCheckPoint % CheckPointCount;
            }
        }
    }
}
