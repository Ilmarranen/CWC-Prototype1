using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerNumber = 1;
    [SerializeField] float speed = 12;
    [SerializeField] float turnSpeed = 40;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get player input
        if (playerNumber == 1)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            verticalInput = Input.GetAxis("Vertical2");
        }

        //Moves the vehicle forward based on horizontal input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //Rotates the vehicle based on vertical input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
