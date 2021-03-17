﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpawnManager : MonoBehaviour
{
    public GameObject spawnPointPrefab;
    public GameObject carPrefab;

    private int difficulty = 3;

    private PlayerController playerControllerScript;
    private float startDelay = 0.0f;
    private float repeatRate = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("spawnCar", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawn a car at a random position
    void spawnCar()
    {
        // determine if car should spawn
        int odds = Random.Range(0, difficulty);
        if (odds == 0)
        {
            return;
        }
        // get the change in spawn position
        int positionXChange = Random.Range(-4, 10);
        // spawn the car
        if (!playerControllerScript.gameOver)
        {
            Vector3 position = new Vector3(transform.position.x + positionXChange, transform.position.y, transform.position.z);
            GameObject carInstance = (GameObject) Instantiate(carPrefab, position, carPrefab.transform.rotation);
            carInstance.name = "RightCarOrange";
        }
    }
}