using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Button leaderboardsButton;
    public Button playAgainButton;
    public Button exitButton;

    private int score;
    private string time;

    // Start is called before the first frame update
    void Start()
    {

        scoreText.GetComponent<Text>().text = "Score: " + score;

        timeText.GetComponent<Text>().text = "Time: " + time;

        leaderboardsButton.GetComponentInChildren<Text>().text = "Leader Boards";
        leaderboardsButton.onClick.AddListener(loaderboardsScene);

        playAgainButton.GetComponentInChildren<Text>().text = "Play Again";
        playAgainButton.onClick.AddListener(gameScene);

        exitButton.GetComponentInChildren<Text>().text = "Exit";
        exitButton.onClick.AddListener(endGame);
    }

    // Update is called once per frame
    void Update()
    {
        // go to game scene if enter is pressed
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            gameScene();
        }

        // go to leaderboard scene if tab is pressed
        if (Input.GetKey(KeyCode.Tab))
        {
            loaderboardsScene();
        }
    }

    // Load the LeaderboardsScene
    void loaderboardsScene()
    {
        SceneManager.LoadScene("LeaderboardsScene");
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

    // Retrieve score and from deleted scene
    void OnEnable()
    {
        score = PlayerPrefs.GetInt("previousScore");
        time = PlayerPrefs.GetString("time");
    }
}
