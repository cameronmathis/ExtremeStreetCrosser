using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float jumpForce = 3.0f;
    public float xRange = 12.0f;
    public float zTopRange = -4.5f;
    public float zBottomRange = -12.5f;

    public bool gameOver = false;

    private Rigidbody playerRigidBody;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
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

    void move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void checkBounds()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopRange);
        }

        if (transform.position.z < zBottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomRange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Road"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            gameOver = true;
            Debug.Log("Game Over");

            playerRigidBody.constraints = RigidbodyConstraints.FreezeAll;
            playerRigidBody.freezeRotation = true;
            transform.Rotate(90, 0, 0, Space.World);
        }
    }
}
