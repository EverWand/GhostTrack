using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class GenericProp : MonoBehaviour
{
    private SphereCollider collision;
    public GameObject interactPrompt;
    private Material defaultMat;
    public Material swapMat;
    [HideInInspector]
    public bool isHinting;
    private bool isGhostHiding;

    private MeshRenderer meshRend;

    public float decoyCooldown;
    private float currentCooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<SphereCollider>();
        interactPrompt.SetActive(false);
        meshRend = GetComponent<MeshRenderer>();
        defaultMat = meshRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHinting && !isGhostHiding)
        {
            if (currentCooldownTime < decoyCooldown)
            {
                currentCooldownTime += Time.deltaTime;
            }
            else
            {
                isHinting = false;
                SwapMaterial(isHinting);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<GhostController>() != null || other.gameObject.GetComponent<Tracker1_Movement>() != null || other.gameObject.GetComponent<Tracker2_Movement>() != null)
        {
            DisplayPrompt();
            //other.gameObject.SendMessage("CanInteract", this.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GhostController>() != null || other.gameObject.GetComponent<Tracker1_Movement>() != null || other.gameObject.GetComponent<Tracker2_Movement>() != null)
        {
            HidePrompt();
            //other.gameObject.SendMessage("CanInteract", other.gameObject);
        }
    }

    public void DisplayPrompt()
    {
        interactPrompt.SetActive(true);
    }

    public void HidePrompt()
    {
        interactPrompt.SetActive(false);
    }

    public void GhostInteract(bool isDecoy)
    {
        if(isHinting)
        {
            isHinting = false;
            SwapMaterial(isHinting);
        }
        else
        {
            isHinting = true;
            SwapMaterial(isHinting);
        }

        if(isDecoy)
        {
            isGhostHiding = false;
            currentCooldownTime = 0;
        }
        else
        {
            isGhostHiding = true;
        }
    }

    public void TrackerInteract()
    {
        if(isHinting)
        {
            if (isGhostHiding)
            {
                //eject ghost
                GameObject.FindObjectOfType<GhostController>().EjectGhost();
            }
            else
            {
                //stun players
            }
        }
    }

    private void SwapMaterial(bool hinting)
    {
        if(hinting)
        {
            meshRend.material = swapMat;
        }
        else
        {
            meshRend.material = defaultMat;
        }
    }
}
