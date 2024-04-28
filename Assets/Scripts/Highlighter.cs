using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    // Initalizing fields

    public bool isHighlighted = false;

    // Update is called once per frame
    void Update() {
        /*// If the mouse is over the object and it is not highlighted. Highlight the object.
        if (lookingAtObject == true && isHighlighted == false) {
            highlighter(selectedObject);
        // If the mouse isn't over the object but it is highlighted. Unhighlight the object.
        } else if (lookingAtObject == false && isHighlighted == true){
            dehighlight(selectedObject);
        }*/
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
