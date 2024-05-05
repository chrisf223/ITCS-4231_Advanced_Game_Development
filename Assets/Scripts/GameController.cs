using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public GameObject SpawnManager

    public GameOverScreen GameOverScreen;
    public WinGameScreen WinGameScreen;

    // Maximum amount of anomalies allowed to be active at once, more than 5 = lose game
    public int maxAnomalies = 5;
    public int currentAnomaliesActive = 0;

    // Maximum number of false reports allowed. 5 false reports = lose game
    public int maxFalseReports = 5;
    public int currentFalseReports = 0;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI falseReportText;


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
            timeText.text = "12:00 AM";
        } else
        {
            timeText.text = truncatedTimeValue.ToString() + ":00 AM";
        }

        falseReportText.text = "False Reports: " + currentFalseReports.ToString() + "/5";

        if(GameObject.Find("SpawnManager").GetComponent<EnemiesSpawnManager>().activeEnemies > maxAnomalies || currentFalseReports >= maxFalseReports)
        {
            GameOver();
        }


        if (gameTime >= levelDuration)
        {
            WinGame();
        }
        
        
        // Auto Win/Lose Game and increase false reports, for testing only
        if (Input.GetKeyDown(KeyCode.W))
        {
            WinGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentFalseReports++;
        }
        
    }

    public void GameOver()
    {
        GameObject.Find("SpawnManager").GetComponent<EnemiesSpawnManager>().enabled = false;
        GameObject.Find("CamManager").GetComponent<CameraManager>().enabled = false;
        this.enabled = false;

        GameOverScreen.Setup();
    }

    public void WinGame()
    {
        GameObject.Find("SpawnManager").GetComponent<EnemiesSpawnManager>().enabled = false;
        GameObject.Find("CamManager").GetComponent<CameraManager>().enabled = false;
        this.enabled = false;

        WinGameScreen.Setup();
    }


}
