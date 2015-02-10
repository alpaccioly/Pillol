using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterBaseState : State<CharacterBehaviour>
{
    public CharacterBaseState()
    {
    }

    public void triggerHit(BulletBehaviour bullet)
    {
        const float c = 3f , p1= 1f , p2= 1f;
        float damage = c * bullet.Aj / Fsm.Entity.Dp * (p1 * bullet.Aa * bullet.Aj - p2 / bullet.Rj / bullet.Rj);
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
