using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = "Score: 0";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    // Store the score when the scene is deleted
    void OnDisable()
    {
        // store the previous attempts score
        PlayerPrefs.SetInt("previousScore", score);
        // check is the previous attempt is a new high score
        bool isLeaderboardFull = true;
        for (int i = 7; i >= 0; i--)
        {
            if (!PlayerPrefs.HasKey("highName" + 0) && !PlayerPrefs.HasKey("highScore" + 0))
            {
                PlayerPrefs.SetString("highName" + 0, "temp");
                PlayerPrefs.SetInt("highScore" + 0, score);
                break;
            }
            else if (!PlayerPrefs.HasKey("highName" + i) && !PlayerPrefs.HasKey("highScore" + i))
            {
                isLeaderboardFull = false;
                continue;
            }
            else
            {
                for (int ii = i; ii >= 0; ii--)
                {
                    if (score > PlayerPrefs.GetInt("highScore" + ii))
                    {
                        if (ii < 7)
                        {
                            string nameToMoveDown = PlayerPrefs.GetString("highName" + ii);
                            PlayerPrefs.SetString("highName" + (ii + 1), nameToMoveDown);

                            int scoreToMoveDown = PlayerPrefs.GetInt("highScore" + ii);
                            PlayerPrefs.SetInt("highScore" + (ii + 1), scoreToMoveDown);
                        }
                        PlayerPrefs.SetString("highName" + ii, "temp");
                        PlayerPrefs.SetInt("highScore" + ii, score);
                        continue;
                    }
                    else if (!isLeaderboardFull)
                    {
                        PlayerPrefs.SetString("highName" + (i + 1), "temp");
                        PlayerPrefs.SetInt("highScore" + (i + 1), score);
                    }
                    break;
                }
                break;
            }
        }
    }
}
