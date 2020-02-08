using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set;}
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private PlayerStateMachine _stateMachine;
    public Animator Animator { get; private set; }

    /*
     * Player Designer-Friendly Data
     * TODO: Move to a ScriptableObject
     */
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    public float Speed { get { return _speed; } }
    public float JumpForce { get { return _jumpForce; } }
    
    public void Awake()
    {
        Instance = this;
        Animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _stateMachine = GetComponent<PlayerStateMachine>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SpawnPlayer(Vector3 position)
    {
        transform.position = position;
    }
        
    
    public void Move(Vector2 move)
    {
        transform.Translate(new Vector2( Time.deltaTime * move.x,0f));
    }

    public void Idle()
    {
        _stateMachine.SetState(new IdleState(this));
    }
    
    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    public void EnterCutscene()
    {
        _stateMachine.SetState(new CutsceneState(this));    
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
    
    public bool IsFalling()
    {
        return _rigidbody2D.velocity.y > 0;
    }
    
    public void FlipSprite()
    {
        _spriteRenderer.flipX = true;
    }
    public void UnFlipSprite()
    {
        _spriteRenderer.flipX = false;
    }
}
