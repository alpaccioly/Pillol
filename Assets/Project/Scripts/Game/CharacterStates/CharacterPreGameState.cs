using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterPreGameState<T> : CharacterBaseState
{
    public void triggetStartGame()
    {
        Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
    }

    public override void Start()
    {
    }
    
    public override void Update()
    {
    }
    
    public override void End()
    {
    }
}
