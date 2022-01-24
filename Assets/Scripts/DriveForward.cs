using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveForward : MonoBehaviour
{
    public float speed = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
