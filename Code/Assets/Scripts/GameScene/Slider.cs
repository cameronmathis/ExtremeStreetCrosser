using UnityEngine;

public class Slider : MonoBehaviour
{
    private float forwardSlideSpeed;
    private string mode;
    private float reverseSlideSpeed = 1.2f;

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
        forwardSlideSpeed = playerControllerScript.movementSpeed;
        mode = PlayerPrefs.GetString("mode");
        lockedVertical = playerControllerScript.lockedVertical;
        isOnGround = playerControllerScript.isOnGround;
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            forwardSlideSpeed = playerControllerScript.movementSpeed;
            lockedVertical = playerControllerScript.lockedVertical;
            isOnGround = playerControllerScript.isOnGround;
            slide();
            checkBounds();
        }
    }

    // Slide the world objects
    void slide()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Slide the object towards the player to make it appear as if the player is walking
        if (moveVertical != 0.0f)
        {
            if (playerGameObject.transform.position.z >= zTopRange)
            {
                Vector3 movement;
                if (isOnGround)
                {
                    movement = new Vector3(0.0f, 0.0f, -moveVertical);
                    transform.Translate(movement * forwardSlideSpeed * Time.deltaTime, Space.World);
                }
                // Keep the object sliding in the locked direction while the player is in the air
                else
                {
                    movement = new Vector3(0.0f, 0.0f, -lockedVertical);
                    transform.Translate(movement * forwardSlideSpeed * Time.deltaTime, Space.World);
                }
            }
        }
        else if (mode.Equals("hard"))
        {
            // Slide the object towards the player when they are not moving
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            transform.Translate(movement * reverseSlideSpeed * Time.deltaTime, Space.World);
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
