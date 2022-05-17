using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    private void Start()
    {
        dir = target.position - transform.position;
    }
    private void Update()
    {
        Move();
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
