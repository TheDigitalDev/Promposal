using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class State
    {
        public bool IsComplete { get; private set; } = false;
        public State ExitState { get; private set; }= null;
        public Player player { get; private set; }
        
        public State(Player player)
        {
            this.player = player;
        }
        
        public virtual void Update() {}
        public virtual void Enter()  {}

        public virtual void HandleCollisionEnter(Collision2D collision) {}
        public virtual void HandleCollisionExit(Collision2D collision) {}
        public virtual void HandleTriggerEnter(Collider2D collider2D) {}
        public virtual void HandleTriggerExit(Collider2D collider2D) {}

        public void Exit(State exitState)
        {
            IsComplete = true;
            ExitState = exitState;
        }
    }
}