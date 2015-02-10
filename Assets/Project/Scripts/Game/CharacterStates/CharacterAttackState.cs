using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterAttackState<T> : State<CharacterBehaviour>
{
    float time = 3.0f;
    Transform enemy;

    public CharacterAttackState(Transform enemy)
    {
        this.enemy = enemy;
    }

    public override void Start()
    {

    }
    
    public override void Update()
    {
        time -= Time.deltaTime;

        if (time < 0f)
        {
            time = 3.0f;

            if (enemy != null)
                Fsm.Entity.Attack(enemy);
        }
    }
    
    public override void End()
    {
    }
}
