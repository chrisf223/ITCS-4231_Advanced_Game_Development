using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
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
        print(currentCamera);

        cameras[currentCamera].enabled = false;

        currentCamera++;

        if (currentCamera >= cameras.Length)
        {
            currentCamera = 0;
        }

        cameras[currentCamera].enabled = true;
    }

    void prevCamera()
    {
        print(currentCamera);

        cameras[currentCamera].enabled = false;

        currentCamera--;

        if (currentCamera < 0)
        {
            currentCamera = cameras.Length - 1;
        }

        cameras[currentCamera].enabled = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            prevCamera();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nextCamera();
        }

    }
}
