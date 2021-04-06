using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsSceneController : MonoBehaviour
{
    public Button easyModeButton;
    public Button hardModeButton;
    public Button clearLocalLeaderboardButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        easyModeButton.GetComponentInChildren<Text>().text = "Easy Mode";
        easyModeButton.onClick.AddListener(easyMode);
        hardModeButton.GetComponentInChildren<Text>().text = "Hard Mode";
        hardModeButton.onClick.AddListener(hardMode);
        clearLocalLeaderboardButton.GetComponentInChildren<Text>().text = "Clear Leader Board";
        clearLocalLeaderboardButton.onClick.AddListener(clearLocalLeaderboard);
        backButton.GetComponentInChildren<Text>().text = "Back";
        backButton.onClick.AddListener(startScene);
    }

    // Update is called once per frame
    void Update()
    {
        // go to start scene if escape is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            startScene();
        }
    }

    // Set the game mode to easy
    void easyMode()
    {

    }

    // Set the game maode to hard
    void hardMode()
    {

    }

    // Clear the local leaderboard
    void clearLocalLeaderboard()
    {
        PlayerPrefs.DeleteAll();
    }

    // Load the StartScene
    void startScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
