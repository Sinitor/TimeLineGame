using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRange : GoblinMove
{
    [SerializeField] private GameObject stone;
    [SerializeField] private Transform target;
   private void Update()
    {
        fireCountDown -= Time.deltaTime; 
        Shoot();
        Walk();
        Flip();
    }
    private void Shoot()
    {
        if (fireCountDown <= 0f)
        {
            fireCountDown = 0f;
        }
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            anim.SetBool("Walk", false);
            speed = 0;
            if (fireCountDown <= 0f)
            {
                anim.SetBool("Cast", true);
                fireCountDown = 6f / fireRate;
                StartCoroutine(StonePref());
            }
            else
            {
                anim.SetBool("Cast", false);
            }
        }
    } 
    IEnumerator StonePref()
    {
        yield return new WaitForSeconds(0.8f);
        GameObject projectileGo = Instantiate(stone, target.position, target.rotation);
    }
}
