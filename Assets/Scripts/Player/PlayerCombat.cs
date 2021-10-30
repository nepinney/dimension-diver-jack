using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack_0();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack_1();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack_2();
        }

    }

    void Attack_0 () 
    {
        // Play attack animation
        animator.SetTrigger("Attack_0");
        // Detect enemies within range of attack
        // Damage them

     }
         void Attack_1 () 
    {
        // Play attack animation
        animator.SetTrigger("Attack_1");
        // Detect enemies within range of attack
        // Damage them

     }
         void Attack_2 () 
    {
        // Play attack animation
        animator.SetTrigger("Attack_2");
        // Detect enemies within range of attack
        // Damage them

     }
}
