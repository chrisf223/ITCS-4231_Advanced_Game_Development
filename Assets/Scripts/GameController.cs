using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    public WinGameScreen WinGameScreen;

    // Maximum amount of anomalies allowed to be active at once, more than 5 = lose game
    public int maxAnomalies = 5;
    public int currentAnomaliesActive = 0;

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

        if(currentAnomaliesActive > maxAnomalies)
        {
            this.enabled = false;
            GameOver();
        }

        if(gameTime >= levelDuration)
        {
            this.enabled = false;
            WinGame();
        }
        
        // Auto Win/Lose Game, for testing only
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.enabled = false;
            WinGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.enabled = false;
            GameOver();
        }

    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void WinGame()
    {
        WinGameScreen.Setup();
    }


}
