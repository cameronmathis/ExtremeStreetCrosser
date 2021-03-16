using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float xRange = 35.0f;
    public float zTopRange = -4.5f;
    public float zBottomRange = -26.9f;
    public GameObject carPrefab;

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

    void checkBounds()
    {
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < zBottomRange)
        {
            Destroy(gameObject);
        }
    }
}
