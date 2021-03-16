using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float zTopRange = -4.5f;
    public GameObject roadPrefab;

    private Vector3 spawnPos = new Vector3(0.0f, 0.12f, 18.0f);
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
        if (playerGameObject.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(0.0f, 0.0f, -moveVertical);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    void checkBounds()
    {
        if (transform.position.z < -26.9)
        {
            GameObject roadInstance = (GameObject)Instantiate(roadPrefab, spawnPos, roadPrefab.transform.rotation);
            roadInstance.name = "Road";
            Destroy(gameObject);
        }
    }
}
