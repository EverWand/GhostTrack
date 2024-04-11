using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    public GameObject owner;
    public float currentHealth;
    public float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            Destroy(owner);
        }
    }

    public void TakeDamageOverTime(float amountPerSecond)
    {
        currentHealth -= amountPerSecond * Time.deltaTime;
    }
}
