using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostHealth : MonoBehaviour
{
    public GameObject owner;
    public float currentHealth;
    public float maxHealth;
    public UnityEvent GhostDied;
    bool hasDied = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            //Destroy(owner); no destroy gho
            if (!hasDied)
            {
                GhostDied.Invoke();
                Debug.Log("DEEEDD");
            }
        }
    }

    public void TakeDamageOverTime(float amountPerSecond)
    {
        currentHealth -= amountPerSecond * Time.deltaTime;
    }
}