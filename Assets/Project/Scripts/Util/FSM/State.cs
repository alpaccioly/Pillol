using UnityEngine;
using System.Collections;

namespace FiniteStateMachine
{
    public abstract class State<T>
    {
        public FSM<T> Fsm;

        public abstract void Start();
        public abstract void Update();
        public abstract void End();
    }
}