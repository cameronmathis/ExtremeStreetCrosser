using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public GameObject blockPrefab;

    private float zTopRange = -4.5f;
    private float zBottomRange = -27.0f;
    private Vector3 spawnPos = new Vector3(0.0f, 0.0f, 27.0f);
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
        if (transform.position.z < zBottomRange)
        {
            GameObject blockInstance = (GameObject) Instantiate(blockPrefab, spawnPos, blockPrefab.transform.rotation);
            blockInstance.name = "Block";
            Destroy(gameObject);
        }
    }

    Vector3 getSpawnPosition(float x, float y, float z)
    {
        Vector3 position = spawnPos;

        position.x = position.x + x;
        position.y = position.y + y;
        position.z = position.z + z;

        return position;
    }
}
