using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public TextMeshProUGUI text;

    public int startTime = 0;
    public int endTime = 6;

    // Minutes of play time IRL
    public float levelDuration = 6.0f;

    [SerializeField]
    // How much RL time has actually passed;
    float actualTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;

        float gameTime = (actualTime / (levelDuration * 60.0f)) * endTime - startTime;

        int truncatedTimeValue = (int)gameTime;

        if(truncatedTimeValue == 0) {
            text.text = "12:00 AM";
        } else
        {
            text.text = truncatedTimeValue.ToString() + ":00 AM";
        }

        if(gameTime >= levelDuration)
        {
            this.enabled = false;

        }


    }
}
