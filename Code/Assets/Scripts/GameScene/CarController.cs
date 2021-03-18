using UnityEngine;

public class CarController : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public float xRange = 50.0f;
    public GameObject carPrefab;

    private float zTopRange = -4.5f;
    private float zBottomRange = -27.0f;

    private PlayerController playerControllerScript;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerGameObject = GameObject.Find("Player");
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

    // Make the car move
    void move()
    {
        float moveVertical = 0.0f;
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        Vector3 movement = new Vector3(3.0f * (transform.rotation.y / 0.7071068f), 0.0f, -moveVertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    // Delete the car once it is off screen
    void checkBounds()
    {
        // check left bound
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }

        // check right bound
        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }

        // check bottom bound
        if (transform.position.z < zBottomRange)
        {
            Destroy(gameObject);
        }
    }
}
