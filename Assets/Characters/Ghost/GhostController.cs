using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GhostController : MonoBehaviour
{
    //rigidbody for player
    private Rigidbody pawnRB;

    //movement key inputs
    public KeyCode moveUpKey;
    public KeyCode moveDownKey;
    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode interactKey;

    //public floats
    public float moveSpeed;

    public GameObject interactProp;

    // Start is called before the first frame update
    void Start()
    {
        //getting rigidbody from self
        pawnRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.Three, out bool xPressed, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three))
        {
            if(xPressed)
            {
                if(interactProp != null)
                {
                    Debug.Log("Ghost Pressed Interact");
                }
            }
        }

        else if (Input.GetKeyDown(interactKey))
        {
            if (interactProp != null && interactProp != this.gameObject)
            {
                Debug.Log("Ghost Pressed Interact");
            }
        }

        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three))
        {
            MoveJoystick(new Vector3(joystick.y, 0, joystick.x));
        }

        else
        {
            if (Input.GetKey(moveUpKey))
            {
                MoveUp();
            }

            if (Input.GetKey(moveDownKey))
            {
                MoveDown();
            }

            if (Input.GetKey(moveRightKey))
            {
                MoveRight();
            }

            if (Input.GetKey(moveLeftKey))
            {
                MoveLeft();
            }
        }
    }

    public void CanInteract(GameObject propReference)
    {
        interactProp = propReference;
    }



    public void MoveUp()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(0, 0, 1) * moveSpeed / Time.deltaTime;
        //add force to rigidbody
        pawnRB.AddForce(upMovement);
    }

    public void MoveDown()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(0, 0, -1) * moveSpeed / Time.deltaTime;
        //add force to rigidbody
        pawnRB.AddForce(upMovement);
    }

    public void MoveRight()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(1, 0, 0) * moveSpeed / Time.deltaTime;
        //add force to rigidbody
        pawnRB.AddForce(upMovement);
    }

    public void MoveLeft()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(-1, 0, 0) * moveSpeed / Time.deltaTime;
        //add force to rigidbody
        pawnRB.AddForce(upMovement);
    }

    public void MoveJoystick(Vector3 moveVector)
    {
        //Create vector for movement
        Vector3 joyMovement = moveVector * moveSpeed / Time.deltaTime;
        //add force to rigidbody
        pawnRB.AddForce(joyMovement);
    }
}
