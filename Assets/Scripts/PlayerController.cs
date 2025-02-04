using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FollowPlayer cameraController;

    private float speed = 10.0f;
    private Rigidbody playerRb;
    private float zBound = 10;
    private float xBound = 10;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Movement of player
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //  Which way does the camera face?
        var direction = cameraController.GetFlatDirection();

        playerRb.AddForce(direction * speed * verticalInput);
        playerRb.AddForce(direction * speed * horizontalInput);
    // Pervent player go off scrren 
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }       
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);  
        }


        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }       
        if (transform.position.x >xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);  
        }
    }
}
