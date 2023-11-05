using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{

    public int movementSpeed = 10;
    private Rigidbody rb;
    private ScoreGet score;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = GetComponent<ScoreGet>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Debug.Log("horizotal = " + horizontalInput);
        // Debug.Log("vertiacl =" + verticalInput);
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Calculate the force based on user input and moveForce.
        Vector3 force = movement.normalized * movementSpeed;

        // Apply the force based on the selected ForceMode.
        rb.AddForce(force, ForceMode.Force);

    }

    //collision

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Target"))
        {
            Debug.Log("touch");
            score.Touch = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Target"))
        {
            Debug.Log("not");
            score.Touch = false;
        }
    }
}
