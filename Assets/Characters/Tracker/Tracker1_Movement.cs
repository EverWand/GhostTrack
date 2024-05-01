using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tracker1_Movement : MonoBehaviour
{
    public enum TrackerSlots { ONE, TWO };
    //public floats
    public TrackerSlots TrackerID;


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
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two))
        {
            Vector3 movementVector = transform.forward.normalized * joystick.y;

            Debug.Log(movementVector);
            rb.AddForce(movementVector * Time.deltaTime * moveSpeed, ForceMode.Force);

            //transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, joystick.x * rotationSpeed * Time.deltaTime, 0));
        }
    }

}


/* OLD TRY AT 2-TRACKER CONTROLLER
 
switch (TrackerID)
{
    case TrackerSlots.ONE:
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One))
        {
            Vector3 movementVector = transform.forward.normalized * joystick.y;

            Debug.Log(movementVector);
            rb.AddForce(movementVector * Time.deltaTime * moveSpeed, ForceMode.Force);

            //transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, joystick.x * rotationSpeed * Time.deltaTime, 0));
        }
        break;

    case TrackerSlots.TWO:
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick2, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two))
        {
            Vector3 movementVector = transform.forward.normalized * joystick2.y;

            Debug.Log(movementVector);
            rb.AddForce(movementVector * Time.deltaTime * moveSpeed, ForceMode.Force);

            //transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, joystick2.x * rotationSpeed * Time.deltaTime, 0));
        }
        break;
}*/

