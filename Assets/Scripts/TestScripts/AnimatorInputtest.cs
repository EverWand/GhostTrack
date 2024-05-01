using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInputtest : MonoBehaviour
{
    //Dakota Thatcher
    //-----animation stuff-----
    [SerializeField] Animator AnimationController; //reference meant to be filled out in the inspector, used to change the locomotion animations
    float forwardsInput = 0; //data to be passed to animator, value should be -1 to 1
    public bool isStunned = false;
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
        Move(Time.deltaTime);
    }

    public void Move(float deltaTime)
    {
        forwardsInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementVector = transform.forward.normalized * forwardsInput;

        //Debug.Log(movementVector);
        rb.AddForce(movementVector * deltaTime * moveSpeed, ForceMode.Force);

        //transform.Translate(new Vector3(0, 0, movementVector * Time.deltaTime));
        transform.Rotate(new Vector3(0, horizontalInput * rotationSpeed * deltaTime, 0));

        //-----Animation Stuff-----
        UpdateAnimator();
        //-----Animation Stuff-----
      
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
