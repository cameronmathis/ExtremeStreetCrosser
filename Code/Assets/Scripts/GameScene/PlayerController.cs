using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    private float lockedHorizontal = 0.0f;
    private float lockedVertical = 0.0f;

    private float jumpForce = 3.0f;
    private bool isOnGround = true;

    private float zTopRange = -4.5f;
    private float zBottomRange = -12.5f;

    public bool gameOver = false;

    private Rigidbody playerRigidBody;
    private Animator playerAnimator;

    private AudioSource playerAudio;
    private AudioSource gameAudio;
    private float audioVolume = 0.5f;
    public AudioClip jumpSound;
    public AudioClip crossWalkSound;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
        gameAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
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
            // update movement speed
            movementSpeed = 8.0f;
            // play jump sound
            playerAudio.PlayOneShot(jumpSound, 1.0f);
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
        if (transform.position.x > calculateXRange(transform.position.z))
        {
            transform.position = new Vector3(calculateXRange(transform.position.z), transform.position.y, transform.position.z);
        }

        // check right bound
        if (transform.position.x < -calculateXRange(transform.position.z))
        {
            transform.position = new Vector3(-calculateXRange(transform.position.z), transform.position.y, transform.position.z);
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

    // Calculate the x range given the z position
    float calculateXRange(float z)
    {
        float result = (z + 34.5f) / 2.0f;

        return result;
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
            // play game over sound
            playerAudio.PlayOneShot(gameOverSound, 1.0f);
            // stop the game music
            gameAudio.Stop();
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
