using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterAttackState<T> : CharacterBaseState
{
    float time;
    Transform enemy;

    public CharacterAttackState(Transform enemy)
    {
        this.enemy = enemy;
    }

    public override void Start()
    {
        time = Random.Range(Fsm.Entity.attackFreqMin, Fsm.Entity.attackFreqMax);
    }
    
    public override void Update()
    {
        time -= Time.deltaTime;

        if (time < 0f)
        {
            time = Random.Range(Fsm.Entity.attackFreqMin, Fsm.Entity.attackFreqMax);

            if (enemy != null)
                Fsm.Entity.Attack(enemy);
        }
    }
    
    public override void End()
    {
    }
}
