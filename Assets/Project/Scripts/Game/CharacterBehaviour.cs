using UnityEngine;
using System.Collections;
using Board;
using System.Collections.Generic;
using FiniteStateMachine;

public class CharacterBehaviour : MonoBehaviour
{
    public FSM<CharacterBehaviour> fsm;
    public int TeamNumber;
    private Transform firePointTr;
    private BoardBehaviour board;

    private float lifebar = 1000f;

    // Frequencia de tiro
    public float attackFreqMax = 2f, attackFreqMin = 3f;

    // Arma do atirador
    public float Aa = 10f;
    // Habilidade do jogador
    public float Aj = 10f;
    // Defesa do personagem
    public float Dp = 10f;

    public CharacterBehaviour()
    {
        fsm = new FSM<CharacterBehaviour>(this, new CharacterPreGameState<CharacterBehaviour>());
    }

    // Use this for initialization
    void Awake()
    {
        firePointTr = transform.Find("FirePoint");
        board = transform.parent.parent.GetComponent<BoardBehaviour>();
    }

    void Start()
    {
	 
    }

    public void Attack(Transform alvo)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"));
        go.transform.parent = transform.parent.parent;
        go.transform.localPosition = firePointTr.localPosition + this.transform.localPosition;
        go.transform.localScale = Vector3.one;
        BulletBehaviour bala = go.GetComponent<BulletBehaviour>();
        bala.Chr = this;
        bala.Position = go.transform.localPosition;
        bala.MoveTo(alvo.localPosition, Aa, Aj);
    }

    public Transform FindEnemy()
    {
        Transform nearest = null;
        float nearestDistance = float.PositiveInfinity;
        List<CharacterBehaviour> team = board.GetTeam(TeamNumber == 1 ? 0 : 1);

        foreach (CharacterBehaviour enm in team)
        {
            Vector3 enemyPosition = enm.transform.localPosition;
            Vector3 myPosition = this.transform.localPosition;
            float distance = Vector3.Distance(myPosition, enemyPosition);
            if (enm.Lifebar > 0 && (nearest == null || distance < nearestDistance))
            {
                nearest = enm.transform;
                nearestDistance = distance;
            } 
        }
        return nearest;
    }

    public void Hit(float damage)
    {
        lifebar = Mathf.Max(lifebar - damage, 0f);
    }
		
    public void triggerHit(BulletBehaviour bullet)
    {
        ((CharacterBaseState)fsm.CurrentState).triggerHit(bullet);
    }

    public float Lifebar
    {
        get
        {
            return lifebar;
        }
        set
        {
            lifebar = value;	
        }
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
}