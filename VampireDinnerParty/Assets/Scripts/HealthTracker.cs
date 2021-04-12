using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public GameObject bloodPrefab;
   
    public bool hasDied;

    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            hasDied = true;
            Instantiate(bloodPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            //Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }

    public void RestoreHealth(float amount)
    {
        currentHealth = currentHealth + amount;
    }
}
