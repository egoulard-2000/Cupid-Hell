using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody myRigidbody;
    public Camera cam;

    private Vector3 movement;
    private Vector3 movementVelocity;

    void start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input
        movementVelocity = movement * moveSpeed;

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

        }
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, Input.GetAxisRaw("Vertical") * moveSpeed);
    }
}
