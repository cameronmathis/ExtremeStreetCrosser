using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private float movementSpeed = 6.0f;
    private float playerMovementSpeed;

    private float xRange = 50.0f;
    private float zTopRange = -4.5f;
    private float zBottomRange = -18.0f;

    private PlayerController playerControllerScript;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerMovementSpeed = playerControllerScript.movementSpeed;
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            playerMovementSpeed = playerControllerScript.movementSpeed;
            move();
            checkBounds();
        }
    }

    // Make the vehicle move
    void move()
    {
        float moveVertical = 0.0f;
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        Vector3 movement = new Vector3(3.0f * (transform.rotation.y / 0.7071068f), 0.0f, -moveVertical);
        movement.x = movement.x * movementSpeed;
        movement.z = movement.z * playerMovementSpeed;
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    // Delete the vehicle once it is off screen
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
