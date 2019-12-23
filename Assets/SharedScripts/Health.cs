using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health;

    public void takeDamage(float damage)
    {
        if (health <= 0f)
        {
            Die();

        }
        else if (health > 0f)
        {
            health -= damage;
            Debug.Log(health);
        }

        if (health <= 0f)
            Die();


    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
