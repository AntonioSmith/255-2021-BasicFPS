using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2;
    public float mouseSensitivityX = 10;
    public float mouseSensitivityY = 10;

    private CharacterController pawn;
    private Camera cam;

    float cameraPitch = 0;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }

    void MovePlayer()
    {
        // get input:

        float v = Input.GetAxis("Vertical"); // W + S / UP + DOWN : a value between -1 and 1
        float h = Input.GetAxis("Horizaontal"); // A + D / LEFT + RIGHT : a value between -1 and 1

        transform.position += transform.right(1, 0, 0) * moveSpeed * Time.deltaTime * h;
        transform.position += transform.forward(0, 0, 1) * moveSpeed * Time.deltaTime * v;

        /* More options for how to move the object
        transform.position += new Vector3(moveSpeed * Time.deltaTime * h, 0, 0);                          //   \
        transform.position += new Vector3(-, -, moveSpeed * Time.deltaTime * v);                          //    \  
                                                                                                          //     \    
        transform.position += transform.right(1, 0, 0) * moveSpeed * Time.deltaTime * h;                  //       -- THESE ALL DO THE SAME THING
        transform.position += transform.forward(0, 0, 1) * moveSpeed * Time.deltaTime * v;                //     / 
                                                                                                          //    /
        transform.position += (transform.right * h + transform.forward * v) * moveSpeed * Time.deltaTime; //   / */

        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed * Time.deltaTime;
        pawn.SimpleMove(speed);
    }

    void TurnPlayer()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Rotate(0, h * Time.deltaTime, 0);

        // cam.transform.Rotate(v * mouseSensitivityY, 0, 0);

        cameraPitch += v * mouseSensitivityY;
        cameraPitch = Mathf.Clamp(cameraPitch, 0, 0); // Clamps the camera so it cant rotate 360degrees

        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
}