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
        PlayerPrefs.SetInt("score", score);
    }
}
