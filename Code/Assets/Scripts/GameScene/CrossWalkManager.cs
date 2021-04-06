using UnityEngine;

public class CrossWalkManager : MonoBehaviour
{
    private bool hasAddedScore = false;

    private ScoreManager scoreManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreManagerScript = GameObject.Find("ScoreBoard").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check for a collision
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasAddedScore && collision.gameObject.CompareTag("Player"))
        {
            // update score
            scoreManagerScript.score++;
            hasAddedScore = true;
        }
    }
}
