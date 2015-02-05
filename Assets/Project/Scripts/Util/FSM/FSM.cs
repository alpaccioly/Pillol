using UnityEngine;
using System.Collections;

namespace FiniteStateMachine
{
    public class FSM<T>
    {
        State<T> CurrentState;
        T Entity;

        // Use this for initialization
        public FSM() : this(null)
        {
        }
        public FSM(State<T> initial)
        {
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