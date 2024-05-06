using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportingManager : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI mainText;
    private int left = 0;
    AudioManager audioManager;
    public GameController gc; 

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() {
        // When the mouse is right-clikced on the screen, it should select and highlight an object
        if (Input.GetMouseButtonDown(0)) {
            // Shoots ray out from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // If it hits then highlight it
            if (Physics.Raycast(ray, out hit)) {
                /* if (hit.collider.tag != "Ignore Raycast") {
                    //Debug.Log("Did Hit");
                    selectedObject = GameObject.Find(SelectedObject.selectedObject);
                    Debug.Log("Object Hit: " + selectedObject);
                } else  */
                if (hit.collider.tag == "Enemies") {
                    selectedObject = GameObject.Find(SelectedObject.selectedObject);
                    Destroy(selectedObject);
                    Debug.Log("Did Hit Enemy");
                } else if(hit.collider.tag != "Ignore Raycast" && hit.collider.tag != "Enemies") {
                    left++;
                    if (left >= 5) {
                        gc.GameOver();
                    }
                    else {
                        mainText.text = "False Reports: " + left + "/5";
                        audioManager.PlaySFX(audioManager.incorrect);
                    }
                    
                }
            }
        }

    }



}
