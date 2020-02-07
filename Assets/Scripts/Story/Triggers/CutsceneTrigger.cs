using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private Cutscene _cutscene;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        _cutscene.StartCutscene();
    }
}
