using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class TargetSelect : MonoBehaviour
{
    public GameObject selectedObject;
    public bool lookingAtObject = false;
    public bool isHighlighted = false;
    public GUIManager rep;
    GameObject tempObject;

    // Update is called once per frame
    void Update() {
        // If the mouse is over the object and it is not highlighted. Highlight the object.
        if (lookingAtObject == true && isHighlighted == false) {
            highlighter(selectedObject);
        // If the mouse isn't over the object but it is highlighted. Unhighlight the object.
        } else if (lookingAtObject == false && isHighlighted == true) {
            dehighlight(selectedObject);
        }
    }

    // When mouse is over the object, set lookingAtObject to true.
    void OnMouseOver() {
        if (rep.GUIRepoOn == true) {
            selectedObject = GameObject.Find(SelectedObject.selectedObject);
            tempObject = selectedObject;
            lookingAtObject = true;
            //selectedObject.GetComponent<Outline>().eraseRenderer = false;
            //Debug.Log("Mouse is over GameObject.");
        }
    }

    // When mouse is over the object, set lookingAtObject to false.
    void OnMouseExit() {
        if (rep.GUIRepoOn == true) {
            lookingAtObject = false;
            dehighlight(selectedObject);
            isHighlighted = false;
            //selectedObject.GetComponent<Outline>().eraseRenderer = true;
            selectedObject = null;
            //Debug.Log("Mouse is no longer on GameObject.");
        }
    }

    // This takes the game object given and changes the emission color to it using the material.
    public void highlighter(GameObject objt) {
        objt.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        objt.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
        isHighlighted = true;
    }

    // This undoes the highlighter() function.
    public void dehighlight(GameObject objt) {
        objt.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        isHighlighted = false;
    }
}