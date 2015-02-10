using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterIdleState<T> : CharacterBaseState
{
    private float totalTime = 3f;
    private float time;

    public CharacterIdleState()
    {
        time = totalTime;
    }

    public override void Start()
    {
    }
    
    public override void Update()
    {
        time -= Time.deltaTime;
        if (time <= totalTime)
        {
            time = totalTime;
            Transform enemy = Fsm.Entity.FindEnemy();
            if (enemy != null)
                Fsm.ChangeState(new CharacterAttackState<CharacterBehaviour>(enemy));
        }
    }
    
    public override void End()
    {
    }
}
