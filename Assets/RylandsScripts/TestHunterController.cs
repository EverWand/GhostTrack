using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHunterController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
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
            player.transform.Translate(joystick.x * Time.deltaTime, 0.0f, joystick.y * Time.deltaTime);
        }
    }
}
