using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterIdleState<T> : State<CharacterBehaviour>
{
    public override void Start()
    {
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Transform enemy = Fsm.Entity.FindEnemy();
            if (enemy != null)
                Fsm.ChangeState(new CharacterAttackState<CharacterBehaviour>(enemy));
        }
    }
    
    public override void End()
    {
    }
}
