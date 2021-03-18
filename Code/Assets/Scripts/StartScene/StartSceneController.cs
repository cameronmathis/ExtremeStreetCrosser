using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponentInChildren<Text>().text = "Play";
        playButton.onClick.AddListener(nextScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load the InstructionsScene
    void nextScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
}
