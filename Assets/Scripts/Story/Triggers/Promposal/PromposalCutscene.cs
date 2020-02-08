using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PromposalCutscene : Cutscene
{
    private Player _player;

    public void Start()
    {
        _player = Player.Instance;
    }
    
    public override void StartCutscene()
    {
        PlayableDirector.Play();
        _player.EnterCutscene();
    }

    public override void OnCutsceneStopped()
    {
        _player.Idle();
    }
}
