using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;

    void Start()
    { 
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // take away health per damage dealt
        currentHealth -= damage;

        // play hit animation
        animator.SetTrigger("Hit");

        if(currentHealth <= 0)
        {
            Die();
        }
    
    }

    void Die()
    {
        // play death animation
        animator.SetBool("isDead", true);

        // disable enemy (script) & box collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

