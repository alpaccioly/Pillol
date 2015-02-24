using UnityEngine;
using System.Collections;
using Board;
using System.Collections.Generic;
using FiniteStateMachine;
using GameUtils;

public class CharacterBehaviour : MonoBehaviour
{
	public string NameChar;
    public FSM<CharacterBehaviour> fsm;
    public int TeamNumber;
    private Transform firePointTr;
    private BoardBehaviour board;
	private Transform lifebars;
    public bool isOnScene;
    public int cosID;
	private Transform lifebarTeam;
	private GlobalLifebarBehaviour lfb;
	public CharacterParams Parameters;
	public ArmaParams ArmParam;
    public float Lifebar = 0f;
	public Animator AnimatorController;

    // Use this for initialization
    void Awake()
    {
		AnimatorController = transform.Find ("Skeleton").GetComponent<Animator> ();
        firePointTr = transform.Find("FirePoint");
        fsm = new FSM<CharacterBehaviour>(this, new CharacterPreGameState<CharacterBehaviour>());
		isOnScene = false;


    }

    void Start()
    {
        // Tem que estart aqui no Start
        board = transform.parent.parent.GetComponent<BoardBehaviour>();
		lifebars = board.transform.Find ("Lifebars");

		Color color;
		if (TeamNumber == 0)
			color = new Color(255, 0, 0);
		else
			color = new Color(0, 0, 255);
		transform.FindChild("Base").renderer.material.color = color;

		LoadParametersBalance();
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
        bala.MoveTo(alvo.localPosition,ArmParam.Power , Parameters.Habilidade);
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

	public void LoadParametersBalance(){
		Parameters = BalancingGame.GetCharParams (NameChar);
		ArmParam = BalancingGame.Armas [0];
		Lifebar = Parameters.Life;
	}

	public void SetAnimation(string stateName, float duration)
	{
		AnimatorController.CrossFade(stateName,duration);
	}
}