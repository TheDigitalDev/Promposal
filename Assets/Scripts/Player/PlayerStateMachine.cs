using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    public State CurrentState { get; private set; }

    public Player Player { get; private set; }
    
    public void Awake()
    {
        Player = GetComponent<Player>();
        CurrentState = new IdleState(Player);
    }

    public void SetState(State s)
    {
        CurrentState.Exit(s);
    }
    
    public void Update()
    {
        if (CurrentState.IsComplete && CurrentState.ExitState != null)
        {
            CurrentState = CurrentState.ExitState;
            CurrentState.Enter();
        }
        CurrentState?.Update();
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        CurrentState?.HandleCollisionEnter(collision2D);
    } 
    
    public void OnCollisionExit2D(Collision2D collision2D)
    {
        CurrentState?.HandleCollisionExit(collision2D);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {       
        CurrentState?.HandleTriggerEnter(collider2D);
    }
    
    public void OnTriggerExit2D(Collider2D collider2D)
    {       
        CurrentState?.HandleTriggerExit(collider2D);
    }
}
