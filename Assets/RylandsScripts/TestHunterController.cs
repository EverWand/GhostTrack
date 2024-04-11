using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHunterController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetJoystickInput();
    }

    public void GetJoystickInput()
    {
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One))
        {
            //player.transform.Translate(joystick.x * Time.deltaTime * moveSpeed, 0.0f, joystick.y * Time.deltaTime * moveSpeed);
            Vector3 movementVector = new Vector3(joystick.x * Time.deltaTime * moveSpeed, 0.0f, joystick.y * Time.deltaTime * moveSpeed);

            rb.AddForce(movementVector, ForceMode.Force);
        }
    }
}
