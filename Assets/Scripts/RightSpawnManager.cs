using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpawnManager : MonoBehaviour
{
    public GameObject spawnPointPrefab;
    public GameObject carPrefab;

    private PlayerController playerControllerScript;
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            GameObject carInstance = (GameObject) Instantiate(carPrefab, transform.position, carPrefab.transform.rotation);
            carInstance.name = "RightCarOrange";
        }
    }
}
