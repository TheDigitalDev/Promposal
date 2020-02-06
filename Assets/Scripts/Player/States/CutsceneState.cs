namespace DefaultNamespace
{
    public class CutsceneState : State
    {
        public CutsceneState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.Animator.Play("Jesse_Idle");
        }
    }
}