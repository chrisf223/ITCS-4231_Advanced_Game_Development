using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportingManager : MonoBehaviour
{
    public GameObject selectedObject;

    // Update is called once per frame
    void Update() {
        // When the mouse is right-clikced on the screen, it should select and highlight an object
        if (Input.GetMouseButtonDown(0)) {
            // Shoots ray out from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // If it hits then highlight it
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag != "Ignore Raycast") {
                    //Debug.Log("Did Hit");
                    selectedObject = GameObject.Find(SelectedObject.selectedObject);
                    Debug.Log("Object Hit: " + selectedObject);
                }
            }
        }
    }



}
