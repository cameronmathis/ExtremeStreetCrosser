using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timeText;

    private float seconds;
    private int minutes;
    private int hours;
    private string time;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        timeText.GetComponent<Text>().text = "Time: 00:00:00";
        seconds = 0;
        minutes = 0;
        hours = 0;

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            time = getTime();
        }
        timeText.GetComponent<Text>().text = "Time: " + time;
    }

    // Store the time when the scene is deleted
    void OnDisable()
    {
        PlayerPrefs.SetString("time", time);
    }

    string getTime()
    {
        seconds += Time.deltaTime;
        int secs = (int)seconds;
        if (secs >= 60)
        {
            minutes++;
            seconds = 0;
            secs = 0;
        }
        if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }

        if (hours > 99)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + secs.ToString("00");
    }
}
