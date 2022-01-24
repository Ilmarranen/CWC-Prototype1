using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Switch camera on pressed "v"
        if (Input.GetKeyDown("v"))
        {
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    }
}
