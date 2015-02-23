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
	private Transform lifebars;
    public bool isOnScene;
    public int cosID;
	private Transform lifebarTeam;
	private GlobalLifebarBehaviour lfb;

    public float Lifebar = 1000f;

    // Frequencia de tiro
    public float attackFreqMax = 2f, attackFreqMin = 3f;

    // Arma do atirador
    public float Aa = 10f;
    // Habilidade do jogador
    public float Aj = 10f;
    // Defesa do personagem
    public float Dp = 10f;

    // Use this for initialization
    void Awake()
    {
        firePointTr = transform.Find("FirePoint");
        fsm = new FSM<CharacterBehaviour>(this, new CharacterPreGameState<CharacterBehaviour>());
        isOnScene = false;
    }

    void Start()
    {
        // Tem que estart aqui no Start
        board = transform.parent.parent.GetComponent<BoardBehaviour>();
		lifebars = board.transform.Find ("Lifebars");
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
        Lifebar = Mathf.Max(Lifebar - damage, 0f);
		if (TeamNumber == 0) {
			lifebarTeam = lifebars.transform.Find ("GlobalLifebarA");
			lfb = lifebarTeam.GetComponent<GlobalLifebarBehaviour>() ;
			lfb.Lower (damage);
		} else if (TeamNumber == 1) {
			lifebarTeam = lifebars.transform.Find ("GlobalLifebarB");
			lfb = lifebarTeam.GetComponent<GlobalLifebarBehaviour>() ;
			lfb.Lower (damage);
		}

    }
		
    public void triggerHit(BulletBehaviour bullet)
    {
        ((CharacterBaseState)fsm.CurrentState).triggerHit(bullet);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
}