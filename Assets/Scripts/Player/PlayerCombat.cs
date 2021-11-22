using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat: MonoBehaviour {

  public Animator animator;

  public Transform attackPoint_0;
  public Transform attackPoint_1;
  public Transform attackPoint_2;
  public float attackRange_0 = 0.5f;
  public float attackRange_1 = 0.5f;
  public float attackRange_2 = 0.5f;
  public LayerMask enemyLayers;
  public float attackRate = 2f;
  float nextAttackTime = 0f;

  // Update is called once per frame
  void Update() {
    if (Time.time >= nextAttackTime) {
      if (Input.GetKeyDown(KeyCode.Z)) {
        Attack_0();
        nextAttackTime = Time.time + 1f / attackRate;
      }
      if (Input.GetKeyDown(KeyCode.X)) {
        Attack_1();
        nextAttackTime = Time.time + 1f / attackRate;

      }
      if (Input.GetKeyDown(KeyCode.C)) {
        Attack_2();
        nextAttackTime = Time.time + 1f / attackRate;

      }
    }
  }

  void OnDrawGizmosSelected() {
    if (attackPoint_0 == null)
      return;
    if (attackPoint_1 == null)
      return;
    if (attackPoint_2 == null)
      return;

    Gizmos.DrawWireSphere(attackPoint_0.position, attackRange_0);
    Gizmos.DrawWireSphere(attackPoint_1.position, attackRange_1);
    Gizmos.DrawWireSphere(attackPoint_2.position, attackRange_2);
  }

  void Attack_0() {
    // Play attack animation
    animator.SetTrigger("Attack_0");

    // Detect enemies within range of attack
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint_0.position, attackRange_0, enemyLayers);

    // Damage them
    foreach(Collider2D enemy in hitEnemies) {
      enemy.GetComponent < Enemy > ().TakeDamage(10);
    }
  }

  void Attack_1() {
    // Play attack animation
    animator.SetTrigger("Attack_1");

    // Detect enemies within range of attack
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint_1.position, attackRange_1, enemyLayers);

    // Damage them
    foreach(Collider2D enemy in hitEnemies) {
      enemy.GetComponent < Enemy > ().TakeDamage(22);
    }
  }
  void Attack_2() {
    // Play attack animation
    animator.SetTrigger("Attack_2");

    // Detect enemies within range of attack
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint_2.position, attackRange_2, enemyLayers);

    // Damage them
    foreach(Collider2D enemy in hitEnemies) {
      enemy.GetComponent < Enemy > ().TakeDamage(37);
    }
  }
}