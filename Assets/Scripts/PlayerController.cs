using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float playerNumber = 1;
    [SerializeField] float speed = 12, rpm, horsePower = 0;
    [SerializeField] const float turnSpeed = 40;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<GameObject> allWheels;
    [SerializeField] LayerMask groundLayerMask;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

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

        if(IsOnGround())
        {
            //Moves the vehicle forward based on horizontal input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //Rotates the vehicle based on vertical input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); //from ms to kph. This is legit
            speedometerText.SetText("Speed: " + speed + " kph");
            rpm = Mathf.Round((speed % 30) * 40); //Just some random formula. Not really an rpm
            rpmText.SetText("RPM: " + rpm);
        }
 
    }

    bool IsOnGround()
    {
        //Using raycast because real wheel colliders don't seem to work on this model
        int wheelsOnGround = 0;
        float extraHeight = 0.5f;
        Color rayColor;
        bool raycastHit;

        foreach (GameObject wheel in allWheels)
        {
            MeshCollider wheelCollider = wheel.GetComponent<MeshCollider>();
            raycastHit = Physics.Raycast(wheelCollider.bounds.center, Vector3.down, wheelCollider.bounds.extents.y + extraHeight, groundLayerMask);
            rayColor = raycastHit ? Color.green : Color.red ;
            Debug.DrawRay(wheelCollider.bounds.center, Vector3.down * (wheelCollider.bounds.extents.y + extraHeight), rayColor);

            if (raycastHit)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround >= 3;
    }

}
