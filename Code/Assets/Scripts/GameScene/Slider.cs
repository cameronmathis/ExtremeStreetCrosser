using UnityEngine;

public class Slider : MonoBehaviour
{
    private float slideSpeed;
    private float lockedVertical = 0.0f;

    private bool isOnGround = true;

    private float zTopRange = -4.5f;
    private float zBottomRange = -19.0f;

    private PlayerController playerControllerScript;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        slideSpeed = playerControllerScript.movementSpeed;
        lockedVertical = playerControllerScript.lockedVertical;
        isOnGround = playerControllerScript.isOnGround;
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            slideSpeed = playerControllerScript.movementSpeed;
            lockedVertical = playerControllerScript.lockedVertical;
            isOnGround = playerControllerScript.isOnGround;
            move();
            checkBounds();
        }
    }

    // Move the object towards the player to make it appear as if the player is walking
    void move()
    {
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement;if (isOnGround)
            {
                movement = new Vector3(0.0f, 0.0f, -moveVertical);

                transform.Translate(movement * slideSpeed * Time.deltaTime, Space.World);
            }
            // keep the object sliding in the locked direction while the player is in the air
            else
            {
                movement = new Vector3(0.0f, 0.0f, -lockedVertical);
                transform.Translate(movement * slideSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    // Check bounds
    void checkBounds()
    {
        if (transform.position.z < zBottomRange)
        {
            // destroy object
            Destroy(gameObject);
        }
    }
}
