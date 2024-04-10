using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebugController : MonoBehaviour
{
    //public floats
    public float moveSpeed;
    public float rotationSpeed;

    public KeyCode moveUpKey;
    public KeyCode moveDownKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");


        Vector3 movementDirection = transform.forward;

        Vector3 RotationStep = new Vector3(0, HorizontalInput, 0);
        RotationStep.Normalize();



        if (Input.GetKey(moveUpKey))
        {
            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(moveDownKey))
        {
            transform.Translate(-movementDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        transform.Rotate(RotationStep * rotationSpeed * Time.deltaTime, Space.World);
    }
}