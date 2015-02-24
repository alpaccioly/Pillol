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
		time = 2.3f;
		CharacterBehaviour enemyCB = enemy.gameObject.GetComponent<CharacterBehaviour>();
		if (enemy != null && enemyCB.Lifebar > 0 && enemyCB.isOnScene && Fsm.Entity.isOnScene)
		{   
			Fsm.Entity.SetAnimation("Attack",0.3f);
		}
		else
			Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());

    }
    
    public override void Update()
    {
		if (time<0||!Fsm.Entity.isOnScene)
		{
			Fsm.Entity.Attack(enemy);
			Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
			return;
		}
		time = time - Time.deltaTime;
    }
    
    public override void End()
    {
    }
}
