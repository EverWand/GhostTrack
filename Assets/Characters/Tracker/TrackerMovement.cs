using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackerMovement : MonoBehaviour
{
    //public floats
    public float moveSpeed;
    public float rotationSpeed;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)){
            Vector3 movementVector = new Vector3(joystick.x * Time.deltaTime * moveSpeed, 0.0f, joystick.y * Time.deltaTime * moveSpeed);

            Debug.Log(movementVector);
            rb.AddForce(movementVector, ForceMode.Force);

            //transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3( 0, joystick.x * rotationSpeed * Time.deltaTime, 0));
        }
    }
}