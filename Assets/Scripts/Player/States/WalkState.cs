using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class WalkState : State
    {
        public WalkState(Player player) : base(player)
        {
            
        }

        public override void Update()
        {
            player.Animator.Play("Jesse_Run");

            float moveHorizontal = Input.GetAxis("Horizontal");
            player.Move(new Vector2(player.Speed * moveHorizontal,0f));

            if (moveHorizontal > 0)
            {                
                player.UnFlipSprite();
            }
            
            if(moveHorizontal < 0)
            {                
                player.FlipSprite();
            }

            if (Mathf.Approximately(moveHorizontal, 0))
            {
                Exit(new IdleState(player));
                return;
            }

            if (player.Rigidbody2D.velocity.y > 0)
            {
                Exit(new FallingState(player));
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Exit(new JumpState(player));
                return;
            }
            
        }


    }
}