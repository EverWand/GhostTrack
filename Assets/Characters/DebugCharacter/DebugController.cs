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

    // Rigidbody
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
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = (this.transform.forward.normalized * VerticalInput);

        Vector3 RotationStep = new Vector3(0, HorizontalInput, 0);
        RotationStep.Normalize();
        
        rb.AddForce(movementDirection * Time.deltaTime * moveSpeed);

        transform.Rotate(RotationStep * rotationSpeed * Time.deltaTime, Space.World);
    }
}