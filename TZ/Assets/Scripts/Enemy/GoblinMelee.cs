using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMelee : GoblinMove
{
    [SerializeField] Transform attackPos;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask whatIsPlayer;
    private void Update()
    {
        fireCountDown -= Time.deltaTime;
        Walk();
        Attack();
        Flip();
    } 
    private void Attack()
    {
        if (fireCountDown <= 0)
        {
            fireCountDown = 0;
        }
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
            anim.SetBool("Walk", false);
            speed = 0;
            if (fireCountDown <= 0f)
            {
                anim.SetBool("Cast", true);
                fireCountDown = 6f / fireRate;
                for (int i = 0; i < 1; i++)
                {
                    playerToDamage[i].GetComponent<PlayerHP>().TakeDamage(damage);
                }
            }
            else if (fireCountDown > 0 && fireCountDown < 2)
            {
                anim.SetBool("Cast", false);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.color = Color.red;
    }
}
