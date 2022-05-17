using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHP : MonoBehaviour
{
    [SerializeField] private int hit;
    [SerializeField] private float health;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    } 
    IEnumerator Die()
    {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            health -= hit;
            anim.SetTrigger("Hit");
        }
    }
}
