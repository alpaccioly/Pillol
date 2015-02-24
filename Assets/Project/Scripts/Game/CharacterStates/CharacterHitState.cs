using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterHitState<T> : CharacterBaseState
{
    private float damage;
    private float totalTime = 3f;
    private float time;

    public CharacterHitState(float damage)
    {
        this.damage = damage;
        this.time = this.totalTime;
    }

    public override void Start()
    {
		Fsm.Entity.SetAnimation ("ReciveDamage", 0.1f);
        Fsm.Entity.Hit(damage);
    }
    
    public override void Update()
    {
        time -= Time.deltaTime;
        if (time <= totalTime)
        {
            time = totalTime;
            if (Fsm.Entity.Lifebar > 0)
                Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
            else
                Fsm.ChangeState(new CharacterFaintState<CharacterBehaviour>());
        }
    }
    
    public override void End()
    {
    }
}
