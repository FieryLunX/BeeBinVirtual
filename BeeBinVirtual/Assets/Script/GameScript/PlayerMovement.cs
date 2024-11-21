using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Attributes:")]
    public float BASE_SPEED = 1.0f;

    [Space]
    [Header("Character statistics:")]
    public Vector2 moveDirection;
    public float moveSpeed;
    private Vector2 lastMoveDirection;
    private Animator animator;
    public LayerMask solidObjectsLayer;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    void ProcessInput()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }
    }

    void Move()
    {
        rb.velocity = moveDirection * moveSpeed * BASE_SPEED;
    }

    void Animate()
    {
        if(moveDirection != Vector2.zero)
        {
            animator.SetFloat("moveX", moveDirection.x);
            animator.SetFloat("moveY", moveDirection.y);
        }
        animator.SetFloat("moveMagnitude", moveDirection.magnitude);
        animator.SetFloat("lastMoveX", lastMoveDirection.x);
        animator.SetFloat("lastMoveY", lastMoveDirection.y);
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
