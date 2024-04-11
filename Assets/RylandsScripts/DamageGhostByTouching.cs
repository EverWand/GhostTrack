using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGhostByTouching : MonoBehaviour
{
    public float damage;
    public float fovAngle;
    public float range;

    public GhostHealth[] ghosts;

    //Audio Objects
    public GameObject DamageAudio;
    public GameObject SpottedAudio;

    // Start is called before the first frame update
    void Start()
    {
        ghosts = FindObjectsByType<GhostHealth>(FindObjectsSortMode.None);
        DamageAudio.SetActive(false);
        SpottedAudio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSee())
        {
            GhostHealth ghostHealth = ghosts[0].gameObject.GetComponent<GhostHealth>();

            Debug.Log(ghostHealth);

            ghostHealth.TakeDamageOverTime(damage);

            StartDamageAudio();
        }
        else
        {
            StopDamageAudio();
        }
    }

    public bool CanSee()
    {
        if (IsWithinRange())
        {
            Vector3 vectorToTarget = ghosts[0].transform.position - transform.position;

            float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);

            if (angleToTarget < fovAngle)
            {
                //Debug.Log("Target in FOV");

                // Raise the origin slightly for vision
                Vector3 rayOrigin = transform.position;
                //rayOrigin.y = transform.lossyScale.y / 2;

                // Define our raycast hit
                RaycastHit hit;
                // Do a raycast then output the results to hit
                Physics.Raycast(rayOrigin, vectorToTarget, out hit, range);
                Debug.DrawRay(rayOrigin, vectorToTarget, Color.white, 5.0f);

                // If we can see it
                if (hit.collider != null)
                {
                    //Debug.Log("Hit " + hit.collider);
                    if (hit.collider.gameObject == ghosts[0].gameObject)
                    {
                        StartSpottedAudio();
                        //Debug.Log("Hit Player");
                        return true;
                    }
                    else
                    {
                        //Debug.Log("Hit not the player");
                        return false;
                    }
                }
                else
                {
                    //Debug.Log("Hit Nothing");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    public bool IsWithinRange()
    {
        // assuming that there is only ever one ghost in the scene
        if (Vector3.Distance(transform.position, ghosts[0].transform.position) <= range)
        {
            //Debug.Log("In Range");
            return true;
        }
        else
        {
            //Debug.Log("Out Of Range");
            return false;
        }

    }

    public void StartDamageAudio()
    {
        DamageAudio.SetActive(true);
    }

    public void StopDamageAudio()
    {
        DamageAudio.SetActive(false);
    }

    public void StartSpottedAudio()
    {
        SpottedAudio.SetActive(true);
    }
}
