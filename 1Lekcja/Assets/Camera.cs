using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform Objektobserwowany;
    Vector3 odleglosc;
    // Start is called before the first frame update
    void Start()
    {
        odleglosc = transform.position - Objektobserwowany.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Objektobserwowany.position + odleglosc;
        transform.LookAt(Objektobserwowany);
    }
}
