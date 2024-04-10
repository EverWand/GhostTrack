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

    //public floats
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //getting rigidbody from self
        pawnRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
}
