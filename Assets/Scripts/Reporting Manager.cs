using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the mouse is right-clikced on the screen, it should select and highlight an object
        if (Input.GetMouseButtonDown(0)) {
            // Shoots ray out from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // If it hits then 
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag != "Ignore Raycast") {
                    Debug.Log("Did Hit");
                }
            }
        }
    }
}
