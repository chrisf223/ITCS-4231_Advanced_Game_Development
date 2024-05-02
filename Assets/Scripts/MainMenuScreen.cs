using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void StartButton() {
        this.enabled = false;
        SceneManager.LoadScene("CameraTest");
    }
}
