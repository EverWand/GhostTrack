using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GhostController : MonoBehaviour
{
    public TiltFive.PlayerIndex PlayerID;
    public MeshRenderer[] bodyObjects;
    public SkinnedMeshRenderer[] skinnedBodyObjects;
    public GameObject bodyObj;

    //Sound
    public GameObject HideAudio;
    public GameObject DecoyAudio;

    //rigidbody for player
    private Rigidbody pawnRB;
    public GameObject Body;

    private CapsuleCollider ghostCollision;

    private MeshRenderer visualMesh;

    //movement key inputs
    public KeyCode moveUpKey;
    public KeyCode moveDownKey;
    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode hideKey;
    public KeyCode decoyKey;

    //public floats
    public float moveSpeed;

    private GameObject interactProp;

    private bool isHiding;
    private bool canDecoy;

    public float decoyCooldown;
    private float currentCooldownTime;

    private Vector3 returnPosition;

    // Start is called before the first frame update
    void Start()
    {
        //getting rigidbody from self
        pawnRB = GetComponent<Rigidbody>();
        //getting collision from self
        ghostCollision = GetComponent<CapsuleCollider>();
        //getting mesh renderer from self
        visualMesh = GetComponent<MeshRenderer>();
        //setting decoy to no cooldown for first use
        currentCooldownTime = decoyCooldown;

        HideAudio.SetActive(false);
        DecoyAudio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldownTime < decoyCooldown)
        {
            currentCooldownTime += Time.deltaTime;
        }
        else
        {
            canDecoy = true;
        }

    //interaction
        //hide
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.X, out bool xPressed, TiltFive.ControllerIndex.Right, PlayerID))
        {
            if(xPressed)
            {
                Debug.Log("Pressed a button");

                if(interactProp != null && interactProp != this.gameObject)
                {
                    Debug.Log("Not Null");
                    if (!interactProp.GetComponent<GenericProp>().isHinting || isHiding)
                    {
                        Debug.Log("Hide Called");
                        ToggleHide();
                        CallToProp(interactProp, false);
                        HideSound();
                    }
                }
            }
        }
        //decoy
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.B, out bool bPressed, TiltFive.ControllerIndex.Right, PlayerID))
        {
            if (bPressed)
            {
                if (interactProp != null && interactProp != this.gameObject && !isHiding)
                {
                    if(canDecoy)
                    {
                        CallToProp(interactProp, true);
                        currentCooldownTime = 0f;
                        canDecoy = false;
                        DecoySound();
                    }
                }
            }
        }

        //hide
        if (Input.GetKeyDown(hideKey))
        {
            if (interactProp != null && interactProp != this.gameObject)
            {
                if (!interactProp.GetComponent<GenericProp>().isHinting || isHiding)
                {
                    ToggleHide();
                    CallToProp(interactProp, false);
                    HideSound();
                }
            }
        }
        //decoy
        if (Input.GetKeyDown(decoyKey))
        {
            if (interactProp != null && interactProp != this.gameObject && !isHiding)
            {
                if (canDecoy)
                {
                    CallToProp(interactProp, true);
                    currentCooldownTime = 0f;
                    canDecoy = false;
                    DecoySound();
                }
            }
        }

    //movement
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, PlayerID))
        {
            MoveJoystick(new Vector3(-joystick.y, 0, joystick.x));
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

    private void CallToProp(GameObject propRef, bool isDecoy)
    {
        propRef.SendMessage("GhostInteract", isDecoy);
    }

    public void CanInteract(GameObject propReference)
    {
        interactProp = propReference;
    }

    private void ToggleHide()
    {
        if(!isHiding)
        {
            visualMesh.enabled = false;
            returnPosition = gameObject.transform.position;
            ghostCollision.enabled = false;
            pawnRB.isKinematic = true;
            gameObject.transform.position = interactProp.transform.position;
            isHiding = true;
            foreach (MeshRenderer target in bodyObjects)
            {
                target.enabled = false;
            }
            foreach (SkinnedMeshRenderer target in skinnedBodyObjects)
            {
                target.enabled = false;
            }
            bodyObj.SetActive(false);
        }
        else
        {
            gameObject.transform.position = returnPosition;
            ghostCollision.enabled = true;
            pawnRB.isKinematic = false;
            visualMesh.enabled = true;
            isHiding = false;
            foreach (MeshRenderer target in bodyObjects){
                target.enabled = true;
            }
            foreach (SkinnedMeshRenderer target in skinnedBodyObjects)
            {
                target.enabled = true;
            }
            bodyObj.SetActive(true);
        }
    }

    public void EjectGhost()
    {
        ToggleHide();
    }

    public void MoveUp()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(0, 0, 1) * moveSpeed;
        //add force to rigidbody
        pawnRB.velocity = upMovement;

        RotateToFacing();
    }

    public void MoveDown()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(0, 0, -1) * moveSpeed;
        //add force to rigidbody
        pawnRB.velocity = upMovement;

        RotateToFacing();
    }

    public void MoveRight()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(1, 0, 0) * moveSpeed;
        //add force to rigidbody
        pawnRB.velocity = upMovement;

        RotateToFacing();
    }

    public void MoveLeft()
    {
        //Create vector for movement
        Vector3 upMovement = new Vector3(-1, 0, 0) * moveSpeed;
        //add force to rigidbody
        pawnRB.velocity = upMovement;

        RotateToFacing();
    }

    public void MoveJoystick(Vector3 moveVector)
    {
        //Create vector for movement
        Vector3 joyMovement = moveVector * moveSpeed; //we dont need to use deltatime in this scenario, unity's native physics system will handle velocity for us
        //add force to rigidbody
        pawnRB.velocity = joyMovement;

        RotateToFacing();
        
    }

    void RotateToFacing()
    {
        Vector3 RotVect = pawnRB.velocity;
        RotVect.y = 0;
        Body.transform.rotation = Quaternion.LookRotation(RotVect);
    }

    public void HideSound ()
    {
        HideAudio.SetActive(true);
    }

    public void DecoySound()
    {
        DecoyAudio.SetActive(true);
    }
}
