using UnityEngine;
using System.Collections;
using FiniteStateMachine;
using GameUtils;

public class CharacterBaseState : State<CharacterBehaviour>
{
    public CharacterBaseState()
    {
    }

    public void triggerHit(BulletBehaviour bullet)
    {
       	float c = BalancingGame.General.MasterDamage , p1= BalancingGame.General.ArmaPowerInfluenceDamage ,
			p2= BalancingGame.General.DistanceInfluenceDamage;
        float damage = c * bullet.Aj / Fsm.Entity.Parameters.Defesa * (p1 * bullet.Aa * bullet.Aj + p2 / bullet.Rj / bullet.Rj);
		//Debug.Log(string.Format("Damage {1} {0}",damage,Fsm.Entity.NameChar));
		Fsm.ChangeState(new CharacterHitState<CharacterBehaviour>(damage));
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
