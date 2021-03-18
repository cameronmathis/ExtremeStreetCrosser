using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsSceneController : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponentInChildren<Text>().text = "Start";
        startButton.onClick.AddListener(nextScene);
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
}
