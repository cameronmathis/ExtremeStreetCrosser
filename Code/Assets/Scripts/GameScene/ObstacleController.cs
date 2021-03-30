using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float movementSpeed = 6.0f;

    private float zTopRange = -4.5f;
    private float zBottomRange = -18.0f;

    private PlayerController playerControllerScript;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        movementSpeed = playerControllerScript.movementSpeed;
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            movementSpeed = playerControllerScript.movementSpeed;
            move();
            checkBounds();
        }
    }

    // Move the obstacle towards the player to make it appear as if the player is walking
    void move()
    {
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(0.0f, 0.0f, -moveVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    // Delete the obstacle once it is off screen
    void checkBounds()
    {
        if (transform.position.z < zBottomRange)
        {
            // destroy obstacle
            Destroy(gameObject);
        }
    }
}
