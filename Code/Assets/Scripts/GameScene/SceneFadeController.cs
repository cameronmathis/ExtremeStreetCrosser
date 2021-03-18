using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeController : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private Animator gameSceneAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameSceneAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // fade the screen before switching scenes
        gameSceneAnimator.SetBool("IsGameOver", playerControllerScript.gameOver);
    }

    // Method to wait for a certain amout of seconds
    IEnumerator wait(float waitDelay)
    {
        yield return new WaitForSeconds(waitDelay);
    }
}
