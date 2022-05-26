using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;

    Vector2 movement;

    float inputX;

    public float walkSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // reference
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(inputX, 0);
        animator.SetBool("IsWalking", IsWalking());
        Flip();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }

    bool IsWalking()
    {
        if (movement == Vector2.zero)
            return false;
        else
            return true;

    }

    private void Flip()
    {
        if (inputX < 0)
            spriteRenderer.flipX = true;
        else if (inputX > 0)
            spriteRenderer.flipX = false;
        
    }



}
