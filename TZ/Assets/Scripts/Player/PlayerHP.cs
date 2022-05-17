using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]  private float health;
    [SerializeField] private int hit;
    private Animator anim; 
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        health -= damage;
        if (health <= 0f)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            TakeDamage(hit);
            anim.SetTrigger("Hit");
        }
    } 
}
