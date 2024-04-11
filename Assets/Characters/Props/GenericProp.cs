using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class GenericProp : MonoBehaviour
{
    private SphereCollider collision;
    public GameObject interactPrompt;

    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<SphereCollider>();
        interactPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<GhostController>() != null || other.gameObject.GetComponent<TrackerMovement>() != null)
        {
            DisplayPrompt();
            other.gameObject.SendMessage("CanInteract", this.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GhostController>() != null || other.gameObject.GetComponent<TrackerMovement>() != null)
        {
            HidePrompt();
            other.gameObject.SendMessage("CanInteract", other.gameObject);
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
}
