using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public InputField nameInputField;
    public Button playButton;
    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponentInChildren<Text>().text = "Play";
        playButton.onClick.AddListener(instructionsScene);
        settingsButton.GetComponentInChildren<Text>().text = "Settings";
        settingsButton.onClick.AddListener(settingsScene);

        nameInputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        // go to game scene if enter is pressed
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            instructionsScene();
        }

        // go to settings scene if escape is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            settingsScene();
        }
    }

    // Load the InstructionsScene
    void instructionsScene()
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

    // Load the SettingsScene
    void settingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
