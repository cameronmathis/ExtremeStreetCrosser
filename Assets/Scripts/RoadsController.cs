using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float zTopRange = -4.5f;
    public Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody.transform.position.z >= zTopRange)
        {
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(0.0f, 0.0f, -moveVertical);
            transform.rotation = Quaternion.LookRotation(movement);

            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
