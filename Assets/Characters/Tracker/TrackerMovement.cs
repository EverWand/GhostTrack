using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackerMovement : MonoBehaviour
{
    //public floats
    public float moveSpeed;
    public float rotationSpeed;


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
        if (TiltFive.Input.TryGetStickTilt(out var joystick)){
            transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3( 0, joystick.x * rotationSpeed * Time.deltaTime, 0));
        }
    }
}