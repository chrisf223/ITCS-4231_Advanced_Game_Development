using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ClearSelection : MonoBehaviour
{
    private GameObject selectedObject;

    public void clearAll() {
        selectedObject = GameObject.Find(SelectedObject.selectedObject);
        selectedObject.GetComponent<Outline>().eraseRenderer = false;
    }
}
