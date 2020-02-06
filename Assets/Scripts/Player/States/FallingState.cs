using UnityEngine;

namespace DefaultNamespace
{
    public class FallingState : State
    {
        public FallingState(Player player) : base(player)
        {
            
        }

        public override void Enter()
        {
            player.Animator.Play("Jesse_Idle");
        }

        public override void Update()
        {

            if (player.IsGrounded())
            {
                Exit(new IdleState(player));
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            
            player.Move(new Vector2(player.Speed * moveHorizontal * 1f,0));
            
            if (moveHorizontal > 0)
            {                
                player.UnFlipSprite();
            }
            
            if(moveHorizontal < 0)
            {                
                player.FlipSprite();
            }
        }
        
        public override void HandleTriggerEnter(Collider2D collider)
        {
            if (collider.tag == "Ladder")
            {
                Exit(new LadderClimbState(collider,player));
            }
        }

    }
}