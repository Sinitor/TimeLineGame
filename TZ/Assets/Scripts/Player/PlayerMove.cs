using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 move;
    private float walk;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");  
        move.y = Input.GetAxisRaw("Vertical");
        walk = move.x + move.y * 0.5f;
        anim.SetFloat("Walk", Mathf.Abs(walk));
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        Flip();
    } 

    private void Flip()
    {
        if (move.x < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (move.x > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
