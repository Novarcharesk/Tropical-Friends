using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject woodBundlePrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SpawnWoodBundle();
            Destroy(gameObject);
        }
    }

    private void SpawnWoodBundle()
    {
        Instantiate(woodBundlePrefab, transform.position, Quaternion.identity);
    }
}