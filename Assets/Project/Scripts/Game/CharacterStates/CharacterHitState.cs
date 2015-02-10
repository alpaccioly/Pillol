using UnityEngine;
using System.Collections;
using FiniteStateMachine;

public class CharacterHitState<T> : State<CharacterBehaviour>
{
    private float damage;

    public CharacterHitState(float damage)
    {
        this.damage = damage;
    }

    public override void Start()
    {
        // Entity.Hit(damage);
    }
    
    public override void Update()
    {
    }
    
    public override void End()
    {
    }
}
