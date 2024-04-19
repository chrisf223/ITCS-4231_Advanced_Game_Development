using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Shoots ray out from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out theObject)) {
                selectedObject = theObject.transform.gameObject.name;
                internalObject = theObject.transform.gameObject.name;
            }
        }
    }
}
