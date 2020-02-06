using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PromposalCutscene : Cutscene
{
    public Player player;
    public override void StartCutscene()
    {
        PlayableDirector.Play();
        player.StateMachine.SetState(new CutsceneState(player));
    }

    public override void OnCutsceneStopped()
    {
        player.StateMachine.SetState(new IdleState(player));
    }
}
