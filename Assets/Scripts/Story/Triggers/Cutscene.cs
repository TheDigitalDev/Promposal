using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{

    public PlayableDirector PlayableDirector;
    public bool Repeatable;
    
    public void OnEnable()
    {
        PlayableDirector.stopped += OnPlayableDirectorStopped;
    }

    public void OnDisable()
    {
        PlayableDirector.stopped -= OnPlayableDirectorStopped;
    }

    public virtual void StartCutscene(){}

    public void OnPlayableDirectorStopped(PlayableDirector dir)
    {
        if (!Repeatable)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        OnCutsceneStopped();
    }
    
    public virtual void OnCutsceneStopped(){}
}
