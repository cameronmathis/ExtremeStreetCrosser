using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardsSceneController : MonoBehaviour
{
    public Text namesText;
    public Text scoresText;
    public Button playAgainButton;
    public Button exitButton;

    private PlayerObject[] highNamesAndScores = new PlayerObject[8];

    // Start is called before the first frame update
    void Start()
    {
        namesText.GetComponent<Text>().text = "";
        for (int i = 0; i < 8; i++)
        {
            if (highNamesAndScores[i].name != "Not Stored")
            {
                namesText.GetComponent<Text>().text = namesText.GetComponent<Text>().text +  highNamesAndScores[i].name + "\n";
            }
            else
            {
                namesText.GetComponent<Text>().text = namesText.GetComponent<Text>().text + " \n";
            }
        }

        scoresText.GetComponent<Text>().text = "";
        for (int i = 0; i < 8; i++)
        {
            if (highNamesAndScores[i].score != -9999)
            {
                scoresText.GetComponent<Text>().text = scoresText.GetComponent<Text>().text + highNamesAndScores[i].score + "\n";
            }
            else
            {
                scoresText.GetComponent<Text>().text = scoresText.GetComponent<Text>().text + " \n";
            }
        }

        playAgainButton.GetComponentInChildren<Text>().text = "Play Again";
        playAgainButton.onClick.AddListener(gameScene);

        exitButton.GetComponentInChildren<Text>().text = "Exit";
        exitButton.onClick.AddListener(endGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load the GameScene
    void gameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit the game
    void endGame()
    {
        Application.Quit();
    }

    // Retrieve leaderboard data
    void OnEnable()
    {
        for (int i = 0; i < 8; i++)
        {
            if (PlayerPrefs.HasKey("highName" + i) && PlayerPrefs.HasKey("highScore" + i))
            {
                highNamesAndScores[i] = new PlayerObject(PlayerPrefs.GetString("highName" + i), PlayerPrefs.GetInt("highScore" + i));
            }
            else
            {
                highNamesAndScores[i] = new PlayerObject("Not Stored", -9999);
            }
        }
    }
}
