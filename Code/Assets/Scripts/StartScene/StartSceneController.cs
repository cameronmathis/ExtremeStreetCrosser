using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public InputField nameInputField;
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
        if (nameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("name", "unknown");
            SceneManager.LoadScene("InstructionsScene");
        }
        else if (nameInputField.text.Trim().Length <= 5)
        {
            PlayerPrefs.SetString("name", nameInputField.text.Trim());
            SceneManager.LoadScene("InstructionsScene");
        }
        else
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
