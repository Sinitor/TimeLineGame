using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBtn : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private Animator anim;
    [SerializeField] private float radius;
    private float fireCountDown = 0f;
    private string enemyTag = "Enemy";
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Update()
    {
        fireCountDown -= Time.deltaTime;
    }
    private void UpdateTarget() //Finding the Enemy
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemys)
        {
            float distanceToEnemy = Vector2.Distance(player.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= radius)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    public void Shoot() //Projectile creation
    {
        if (fireCountDown <= 0f && target != null)
        {
            anim.SetTrigger("Cast");
            GameObject projectileGo = Instantiate(fireball, player.position, player.rotation);
            FireBall fireBall = projectileGo.GetComponent<FireBall>();
            if (fireBall != null)
            {
                fireBall.Seek(target);
            }
            fireCountDown = 3f / fireRate;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, radius);
    }
}
