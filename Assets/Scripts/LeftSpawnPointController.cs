using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpawnPointController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float zTopRange = -4.5f;
    public GameObject spawnPointPrefab;
    public GameObject carPrefab;

    private Vector3 spawnPosLeft = new Vector3(-30.0f, 0.2f, 18.0f);
    private PlayerController playerControllerScript;
    private GameObject playerGameObject;
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerGameObject = GameObject.Find("Player");
        //InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            move();
            checkBounds();
        }
    }

    void move()
    {
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(0.0f, 0.0f, -moveVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    void checkBounds()
    {
        if (transform.position.z < -27.9)
        {
            GameObject spawnPointInstance = (GameObject) Instantiate(spawnPointPrefab, spawnPosLeft, spawnPointPrefab.transform.rotation);
            spawnPointInstance.name = "LeftSpawnPoint";
            Destroy(gameObject);
        }
    }

    void spawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            GameObject roadInstance = (GameObject) Instantiate(carPrefab, transform.position, carPrefab.transform.rotation);
            roadInstance.name = "LeftCarOrange";
        }
    }
}
