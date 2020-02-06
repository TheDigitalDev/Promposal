using UnityEngine;

namespace DefaultNamespace
{
    public class JumpState : State
    {

        public JumpState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.Animator.Play("Jesse_Idle");
            Jump();
        }

        private void Jump()
        {
            player.Rigidbody2D.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
        }

        public override void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            player.Move(new Vector2(player.Speed * moveHorizontal * 1f,0f));

            if (player.Rigidbody2D.velocity.y > 0)
            {
                Exit(new FallingState(player));
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