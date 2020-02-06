using UnityEngine;

namespace DefaultNamespace
{
    public class LadderClimbState : State
    {

        private Collider ladder;
        
        public LadderClimbState(Collider2D ladder, Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.Animator.Play("Jesse_Idle");
            player.Rigidbody2D.simulated = false;
            player.transform.position = ladder.transform.position;
        }


        public override void Update()
        {
            player.Move(new Vector2(0,Input.GetAxis("Vertical")));
        }

        public override void HandleTriggerExit(Collider2D collider2D)
        {
            if(collider2D.tag == "Ladder")
            {
                player.Rigidbody2D.simulated = true;
                Exit(new IdleState(player));
            }
        }
    }
}