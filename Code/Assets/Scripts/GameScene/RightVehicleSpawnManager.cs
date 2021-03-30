using UnityEngine;

public class RightVehicleSpawnManager : MonoBehaviour
{
    public GameObject spawnPointPrefab;
    public GameObject[] vehiclePrefab;

    private int difficulty = 3;

    private PlayerController playerControllerScript;
    private float startDelay = 0.0f;
    private float repeatRate = 0.85f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //InvokeRepeating("spawnVehicle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawn a vehicle at a random position
    void spawnVehicle()
    {
        // determine if vehicle should spawn
        int odds = Random.Range(0, difficulty);
        if (odds == 0)
        {
            return;
        }
        // get the change in spawn position
        int positionXChange = Random.Range(-4, 10);
        // determine which vehicle should spawn
        int totalNumberOfVehicles = 5;
        int vehicle = Random.Range(0, totalNumberOfVehicles); ;
        // spawn the vehicle
        if (!playerControllerScript.gameOver)
        {
            Vector3 position = new Vector3(transform.position.x + positionXChange, transform.position.y, transform.position.z);
            GameObject vehicleInstance = (GameObject) Instantiate(vehiclePrefab[vehicle], position, vehiclePrefab[vehicle].transform.rotation);
            vehicleInstance.name = "Vehicle";
        }
    }
}
