using UnityEngine;
using System.Collections;

namespace FiniteStateMachine
{
    public class FSM<T>
    {
        State<T> CurrentState;
        public T Entity;

        // Use this for initialization
        public FSM(T entity) : this(entity, null)
        {
        }
        public FSM(T entity, State<T> initial)
        {
            Entity = entity;
            ChangeState(initial);
        }

        public void ChangeState(State<T> state)
        {
            if (CurrentState != null)
                CurrentState.End();

            CurrentState = state;
            if (CurrentState != null)
            {
                CurrentState.Fsm = this;
                CurrentState.Start();
            }
        }
        
        // Update is called once per frame
        public void Update()
        {
            if (CurrentState != null)
                CurrentState.Update();
        }
    }
}