using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Projectile
{
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dir = target.position - transform.position;
        StartCoroutine(Die());
    }
    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        } 
    } 
    IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
