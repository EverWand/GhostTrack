using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker_Movement : MonoBehaviour
{
    public TiltFive.PlayerIndex PlayerID;

    //Dakota Thatcher
    //-----animation stuff-----
    [SerializeField] Animator AnimationController; //reference meant to be filled out in the inspector, used to change the locomotion animations
    float forwardsInput = 0; //data to be passed to animator, value should be -1 to 1
    public bool isStunned = false;
    public GameObject flashlightPivot; //procedural animation
    public Transform flashlightRotationOffset;
    //-----animation stuff-----

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
        SetFlashlightRotation();
    }

    public void Move()
    {
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, PlayerID))
        {
            Vector3 movementVector = transform.forward.normalized * joystick.y;

            //Debug.Log(movementVector);
            //rb.AddForce(movementVector * Time.deltaTime * moveSpeed, ForceMode.Force);

            transform.Translate(new Vector3(0, 0, joystick.y * moveSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, joystick.x * rotationSpeed * Time.deltaTime, 0));

            //-----Animation Stuff-----
            //calculating animator parameter
            Vector2 inputVec = new Vector2(joystick.x, joystick.y);
            float inputMag = inputVec.magnitude;
            float sign = Mathf.Sign(joystick.y);
            forwardsInput = sign * inputMag;
            UpdateAnimator();
            //-----Animation Stuff-----
        }
    }

    void SetFlashlightRotation()
    {
        Quaternion wandRot = TiltFive.Wand.GetRotation(TiltFive.ControllerIndex.Right, PlayerID);
        flashlightPivot.transform.rotation = wandRot * flashlightRotationOffset.rotation;
    }


    //Code written by Dakota Thatcher

    //function passes data to the animator
    void UpdateAnimator()
    {
        Debug.Log("forwards input passed to animator: " + forwardsInput);
        AnimationController.SetFloat("ForwardsVelocity", forwardsInput);
        AnimationController.SetBool("isStunned", isStunned);
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

