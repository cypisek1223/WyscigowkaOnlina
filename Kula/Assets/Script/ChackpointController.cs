using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackpointController : MonoBehaviour
{

    public int lap = 0;
    public int LastChackpoint = -1;
    int CheckPointCount;

    int NextCheckPoint;

    public GameObject lastPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] poinst = GameObject.FindGameObjectsWithTag("ChackPoint");
        CheckPointCount = poinst.Length;
        foreach(GameObject obj in poinst)
        {
            if(obj.name == "0")
            {
                if (obj.name == "0")
                {
                    lastPoint = obj;
                    break;
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ChackPoint"))
        {
            int currentCheckpoint = int.Parse(other.gameObject.name);
            if (currentCheckpoint == NextCheckPoint)
            {

                LastChackpoint = currentCheckpoint;
                lastPoint = other.gameObject;
                if (LastChackpoint == 0)
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
