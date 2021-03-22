using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    private float lockedHorizontal = 0.0f;
    private float lockedVertical = 0.0f;

    private float jumpForce = 3.0f;
    private bool isOnGround = true;

    private float xRange = 10.0f;
    private float zTopRange = -4.5f;
    private float zBottomRange = -12.5f;

    public bool gameOver = false;

    private Rigidbody playerRigidBody;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            move();
            checkBounds();
        }
    }

    // Move the player as long as it is not at the top Z range
    void move()
    {
        // get input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        // store input
        Vector3 movement;
        
        // check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            movementSpeed = 8.0f;

            // move the player
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // remember the direction moving
            lockedHorizontal = moveHorizontal;
            lockedVertical = moveVertical;

            isOnGround = false;
            // animate the jump
            playerAnimator.SetBool("IsJumping", true);
        }
        // move and animate the player if they are on the ground and haven't jumped
        else if (isOnGround)
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.rotation = Quaternion.LookRotation(movement);

            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

            bool walking = moveHorizontal != 0.0f || moveVertical != 0.0f;
            playerAnimator.SetBool("IsWalking", walking);
        }
        // keep the player moving in the locked direction while in the air
        else
        {
            movement = new Vector3(lockedHorizontal, 0.0f, lockedVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    // Keep the player from walking out of bounds
    void checkBounds()
    {
        // check left bound
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // check right bound
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // check top bound
        if (transform.position.z > zTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopRange);
        }

        // check bottom bound
        if (transform.position.z < zBottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomRange);
        }
    }

    // Check for a collision
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Road"))
        {
            movementSpeed = 6.0f;
            isOnGround = true;
            playerAnimator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.CompareTag("Vehicle"))
        {
            gameOver = true;
            Debug.Log("Game Over");

            // animate the death
            playerAnimator.SetTrigger("DeathTrigger");
            // wait 2 seconds before going to next scene
            Invoke("nextScene", 2);
        }
    }

    // Load the GameOverScene
    void nextScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
