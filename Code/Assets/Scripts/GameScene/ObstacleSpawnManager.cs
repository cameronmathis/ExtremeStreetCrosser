using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn a obstacle at a random spawn point
    void spawnObstacle()
    {
        // determine if obstacle should spawn
        int odds = Random.Range(0, 5);
        if (odds != 0)
        {
            return;
        }
        // get the change in spawn position
        int positionXChange = Random.Range(-5, 5);
        int positionZChange = Random.Range(-1, 2);
        // determine which obstacle should spawn
        int totalNumberOfObstacles = 5;
        int obstacle = Random.Range(0, totalNumberOfObstacles);
        // spawn the obstacle
        Vector3 position = new Vector3(transform.position.x + positionXChange, transform.position.y, transform.position.z + positionZChange);
        GameObject obstacleInstance = (GameObject)Instantiate(obstaclePrefab[obstacle], position, obstaclePrefab[obstacle].transform.rotation);
        obstacleInstance.name = "Obstacle";
    }
}
