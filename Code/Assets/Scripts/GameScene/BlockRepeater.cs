using UnityEngine;

public class BlockRepeater : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public GameObject blockPrefab;

    private float zTopRange = -4.5f;
    private float zBottomRange = -18.0f;
    private Vector3 spawnPos = new Vector3(0.0f, 0.0f, 27.0f);

    private PlayerController playerControllerScript;
    private GameObject playerGameObject;

    private ScoreManager scoreManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerGameObject = GameObject.Find("Player");

        scoreManagerScript = GameObject.Find("ScoreBoard").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            move();
            checkBounds();
        }
    }

    // Move the block towards the player to make it appear as if the player is walking
    void move()
    {
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(0.0f, 0.0f, -moveVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    // Check to ensure the block has not passed more than its width off of the screen
    void checkBounds()
    {
        if (transform.position.z < zBottomRange)
        {
            // spawn new block
            GameObject blockInstance = (GameObject) Instantiate(blockPrefab, spawnPos, blockPrefab.transform.rotation);
            blockInstance.name = "Block";
            // update score
            scoreManagerScript.score++;
            // destroy old block
            Destroy(gameObject);
        }
    }
}
