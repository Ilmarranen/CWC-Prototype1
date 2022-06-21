using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveForward : MonoBehaviour
{
    public float speed = 12;

    // Update is called once per frame
    void Update()
    {
        //Moves the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
