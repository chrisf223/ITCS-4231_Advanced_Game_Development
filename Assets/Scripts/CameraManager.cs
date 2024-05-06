using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : GUIManager
{
    public Camera camera_1;
    public Camera camera_2;
    public Camera camera_3;
    public Camera camera_4;
    public Camera camera_5;

    protected Camera[] cameras;

    protected int currentCamera;

    private void Awake()
    {
        cameras = new Camera[5];


        cameras[0] = camera_1;
        cameras[1] = camera_2;
        cameras[2] = camera_3;
        cameras[3] = camera_4;
        cameras[4] = camera_5;

    }

    void nextCamera()
    {

        cameras[currentCamera].enabled = false;
        cameras[currentCamera].tag = "Non-Main Camera";
        currentCamera++;

        if (currentCamera >= cameras.Length)
        {
            currentCamera = 0;
        }

        cameras[currentCamera].enabled = true;
        cameras[currentCamera].tag = "MainCamera";
        //print("Camera: " + currentCamera + " Tag: " + cameras[currentCamera].tag);
    }

    void prevCamera()
    {

        cameras[currentCamera].enabled = false;
        cameras[currentCamera].tag = "Non-Main Camera";
        currentCamera--;

        if (currentCamera < 0)
        {
            currentCamera = cameras.Length - 1;
        }

        cameras[currentCamera].enabled = true;
        cameras[currentCamera].tag = "MainCamera";
        //print("Camera: " + currentCamera + " Tag: " + cameras[currentCamera].tag);
    }

    // Gets the current camera
    public int getCurrentCamera() {
        return currentCamera;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            prevCamera();
            ChangeCameraText(currentCamera);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nextCamera();
            ChangeCameraText(currentCamera);
        }

    }
}
