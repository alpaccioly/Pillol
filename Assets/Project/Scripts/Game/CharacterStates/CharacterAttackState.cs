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
		time = Random.Range((float)Fsm.Entity.Parameters.FrequenciaAtaqueMin, (float)Fsm.Entity.Parameters.FrequenciaAtaqueMax);
    }
    
    public override void Update()
    {
		if (!Fsm.Entity.isOnScene)
		{
			Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
			return;
		}

        time -= Time.deltaTime;

        if (time < 0f)
        {
            time = Random.Range(Fsm.Entity.Parameters.FrequenciaAtaqueMin, Fsm.Entity.Parameters.FrequenciaAtaqueMax);

            CharacterBehaviour enemyCB = enemy.gameObject.GetComponent<CharacterBehaviour>();
            if (enemy != null && enemyCB.Lifebar > 0 && enemyCB.isOnScene && Fsm.Entity.isOnScene)
                Fsm.Entity.Attack(enemy);
            else
                Fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
        }
    }
    
    public override void End()
    {
    }
}
