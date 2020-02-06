using UnityEngine;

namespace DefaultNamespace
{
    public class IdleState : State
    {

        public IdleState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.Animator.Play("Jesse_Idle");
        }

        public override void Update()
        {
            if (player.Rigidbody2D.velocity.y > 0)
            {
                Exit(new FallingState(player));
                return;
            }
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            
            if (!Mathf.Approximately(moveHorizontal,0))
            {
                Exit(new WalkState(player));
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