using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class TargetSelect : MonoBehaviour
{
    public GameObject selectedObject;
    public bool lookingAtObject = false;
    public GUIManager rep;

    // When mouse is over the object, set lookingAtObject to true.
    void OnMouseOver() {
        if (rep.GUIRepoOn == true) {
            selectedObject = GameObject.Find(SelectedObject.selectedObject);
            lookingAtObject = true;
            selectedObject.GetComponent<Outline>().eraseRenderer = false;
            //Debug.Log("Mouse is over GameObject.");
        }
    }

    // When mouse is over the object, set lookingAtObject to false.
    void OnMouseExit() {
        if (rep.GUIRepoOn == true) {
            lookingAtObject = false;
            selectedObject.GetComponent<Outline>().eraseRenderer = true;
            selectedObject = null;
            //Debug.Log("Mouse is no longer on GameObject.");
        }
    }
}
