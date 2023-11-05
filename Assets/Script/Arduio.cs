using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduio : MonoBehaviour
{
    SerialPort serialPort;
    float movementSpeed = 0.1f;
    public float lowestY = 1;
    public float lowestX = 1;
     private Rigidbody rb;  

    void Start()
    {
        serialPort = new SerialPort("COM7", 9600); // Replace "COM3" with the correct serial port name.
        serialPort.Open();
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            string accelerometerData = serialPort.ReadLine();
            string[] dataParts = accelerometerData.Split(',');

            if (dataParts.Length == 3)
            {
                float X_out, Y_out;
                if (float.TryParse(dataParts[0], out X_out) && float.TryParse(dataParts[1], out Y_out))
                {
                    lowestX = X_out;
                    lowestY = Y_out;

                    MoveCharacter(X_out, Y_out);
                }
            }
        }
    }

    void MoveCharacter(float X_out, float Y_out)
    {
        // float horizontalInput;
        // float verticalInput;
        // if(X_out<=0)
        // {
        //     horizontalInput = -1;
        // }

        // else
        // {
        //     horizontalInput = 1;
        // }

        // if(Y_out<=0)
        // {
        //     verticalInput = -1;
        // }verticalInput = 1;
        // // Adjust the character's position based on the accelerometer data.
        
        // Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        // Vector3 force = movement.normalized * movementSpeed;
        // rb.AddForce(force, ForceMode.Force);
        ////////////////////////////////////////
        Vector3 newPosition;
        if(X_out<=0 && Y_out <= 0)
        {
            newPosition = (Vector3)transform.position - new Vector3(0.1f * lowestX,0, 0.1f * lowestY);
        }

        else if(X_out <= 0 && Y_out >= 0) 
        {
            newPosition = (Vector3)transform.position + new Vector3(0.1f * lowestX,0, -0.1f * lowestY);
        }

        else if(Y_out >=0 && X_out <= 0)
        {
            newPosition = (Vector3)transform.position - new Vector3(lowestX * -0.1f,0, 0.1f * lowestY);
        }

        else {
            newPosition = (Vector3)transform.position + new Vector3(-0.1f * lowestX,0, -0.1f * lowestY);
        }
        
        transform.position = newPosition;
        /////////////////////////////////////////////
        // Vector3 movement = new Vector3(-X_out, 0f, Y_out); // Invert X for left/right and use Y for forward/backward.
        // Vector3 force = movement.normalized * movementSpeed * 10;
        // rb.AddForce(force, ForceMode.Force);
    }

//     void OnApplicationQuit()
//     {
//         serialPort.Close();
//     }
}