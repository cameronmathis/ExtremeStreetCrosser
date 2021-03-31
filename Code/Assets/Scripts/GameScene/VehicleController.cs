using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private float movementSpeed = 6.0f;

    private float xRange = 50.0f;

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

    // Make the vehicle move
    void move()
    {
        Vector3 movement = new Vector3(3.0f * (transform.rotation.y / 0.7071068f), 0.0f, 0.0f);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    // Check bounds
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
    }
}
