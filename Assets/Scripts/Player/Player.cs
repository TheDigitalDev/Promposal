using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

   
    
    public Animator Animator { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    
    public float Speed
    {
        get { return _speed; }
    }

    public float JumpForce
    {
        get { return _jumpForce; }
    }
    
    public void Awake()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StateMachine = GetComponent<PlayerStateMachine>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 move)
    {
        transform.Translate(new Vector2( Time.deltaTime * move.x,0f));
    }
    
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f);
        if (hit.collider != null)
        {
            return hit.collider.tag == "Terrain";
        }
        return false;
    }
    
    public void FlipSprite()
    {
        SpriteRenderer.flipX = true;
    }
    public void UnFlipSprite()
    {
        SpriteRenderer.flipX = false;
    }
}
