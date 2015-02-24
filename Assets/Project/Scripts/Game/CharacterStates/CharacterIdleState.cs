using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterIdleState<T> : CharacterBaseState
{
    private float totalTime = float.PositiveInfinity;
    private float time;

    public CharacterIdleState()
    {
    }

    public override void Start()
    {
		totalTime = GetTime ();
		time = totalTime;
		Fsm.Entity.SetAnimation ("Idle", 1f);
    }
    
    public override void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = totalTime;
            Transform enemy = Fsm.Entity.FindEnemy();
            if (enemy != null && enemy.gameObject.GetComponent<CharacterBehaviour>().isOnScene && Fsm.Entity.isOnScene)
                Fsm.ChangeState(new CharacterAttackState<CharacterBehaviour>(enemy));
        }
    }
    
    public override void End()
    {
    }
	private float GetTime(){
		return Random.Range ((float)Fsm.Entity.Parameters.FrequenciaAtaqueMin, (float)Fsm.Entity.Parameters.FrequenciaAtaqueMax);
	}
}
