using UnityEngine;

public class CrossWalkSpawnManager : MonoBehaviour
{
    public GameObject crossWalk;

    // Start is called before the first frame update
    void Start()
    {
        spawnCrossWalk();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawn a cross walk at a random spawn point
    void spawnCrossWalk()
    {
        // determine if cross walk should spawn
        int odds = Random.Range(0, 5);
        if (odds != 0)
        {
            return;
        }
        // get the change in spawn position
        int positionXChange = Random.Range(-3, 3);
        // spawn the obstacle
        Vector3 position = new Vector3(transform.position.x + positionXChange, transform.position.y, transform.position.z);
        GameObject obstacleInstance = (GameObject)Instantiate(crossWalk, position, crossWalk.transform.rotation);
        obstacleInstance.name = "CrossWalk";
    }
}
