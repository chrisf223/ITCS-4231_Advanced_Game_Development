using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public TextMeshProUGUI CameraName;
    [SerializeField] private GameObject reportGUI;
    [SerializeField] private GameObject defaultGUI;
    public bool GUIRepoOn = false;

    // Start is called before the first frame update
    void Start()
    {
        CameraName.text = "Kitchen";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraText(int camNum) {
        //print("Current num got: " + camNum);
        if (camNum == 0) {
            CameraName.text = "Kitchen";
        } else if (camNum == 1) {
            CameraName.text = "Office";
        } else if (camNum == 2) {
            CameraName.text = "Storage";
        } else if (camNum == 3) {
            CameraName.text = "Barracks";
        } else if (camNum == 4) {
            CameraName.text = "Lab";
        }
    }

    public void ChangeGUItoReporting () {
        reportGUI.SetActive(true);
        //print("Button works!");
        defaultGUI.SetActive(false);
        GUIRepoOn = true;
    }
    
    public void ChangeGUItoDeafult () {
        reportGUI.SetActive(false);
        //print("Button works!");
        defaultGUI.SetActive(true);
        GUIRepoOn = false;
    }
}
