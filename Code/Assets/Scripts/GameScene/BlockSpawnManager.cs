using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public bool hasProducedDuplicate = false;

    private float zBottomRange = -18.0f;
    private float duplicatePoint = 18.0f;

    private Vector3 spawnPos = new Vector3(0.0f, 0.0f, 26.85f);

    private PlayerController playerControllerScript;

    private ScoreManager scoreManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        scoreManagerScript = GameObject.Find("ScoreBoard").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            checkBounds();
        }
    }

    // Check bounds
    void checkBounds()
    {
        if (transform.position.z < zBottomRange)
        {
            // update score
            scoreManagerScript.score++;
        }

        if (transform.position.z < duplicatePoint && !hasProducedDuplicate)
        {
            // spawn new block
            GameObject blockInstance = (GameObject)Instantiate(blockPrefab, spawnPos, blockPrefab.transform.rotation);
            blockInstance.name = "Block";

            hasProducedDuplicate = true;
        }
    }
}
