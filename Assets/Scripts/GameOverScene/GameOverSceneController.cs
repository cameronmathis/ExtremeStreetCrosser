using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Button playAgainButton;
    public Button exitButton;

    private int score;
    private string time;

    // Start is called before the first frame update
    void Start()
    {

        scoreText.GetComponent<Text>().text = "Score: " + score;

        timeText.GetComponent<Text>().text = "Time: " + time;

        playAgainButton.GetComponentInChildren<Text>().text = "Play Again";
        playAgainButton.onClick.AddListener(nextScene);

        exitButton.GetComponentInChildren<Text>().text = "Exit";
        exitButton.onClick.AddListener(endGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load the GameScene
    void nextScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit the game
    void endGame()
    {
        Application.Quit();
    }

    // Retrieve score and from deleted scene
    void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
        time = PlayerPrefs.GetString("time");
    }
}
