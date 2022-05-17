using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMove : MonoBehaviour
{
    [SerializeField] protected private float speed;
    [SerializeField] protected private float angryDistance;
    [SerializeField] protected private Transform player;
    protected private Animator anim;
    [SerializeField] protected private float attackRange;
    [SerializeField] protected private float fireRate = 2f;
    protected private float fireCountDown = 0f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Angry() //Player detection
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, angryDistance);
    }
    public void Walk() //Movement behind the player
    {
        if (Vector2.Distance(transform.position, player.position) >= attackRange)
        {
            if (Vector2.Distance(transform.position, player.position) <= angryDistance)
            {
                anim.SetBool("Cast", false);
                speed = 1;
                anim.SetBool("Walk",true);
                angryDistance = 10;
                Angry();
            }
        }
    }
    public void Flip() //Turn to player
    {
        if (player.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
