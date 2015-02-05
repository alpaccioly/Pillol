using UnityEngine;
using System.Collections;
using Board;
using System.Collections.Generic;
using FiniteStateMachine;

public class CharacterBehaviour : MonoBehaviour
{
    public FSM<CharacterBehaviour> fsm;
    public int TeamNumber;
    public Transform enemy;
    private Transform firePointTr;
    private BoardBehaviour board;

    public CharacterBehaviour()
    {
        fsm = new FSM<CharacterBehaviour>(this, new CharacterIdleState<CharacterBehaviour>());
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
        Debug.Log(go.transform.parent);
        go.transform.localPosition = firePointTr.localPosition + this.transform.localPosition;
        Debug.Log(go.transform.localPosition);
        go.transform.localScale = Vector3.one;
        BulletBehaviour bala = go.GetComponent<BulletBehaviour>();
        bala.Chr = this;
        bala.Position = go.transform.localPosition;
        bala.MoveTo(alvo.localPosition);
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
            if (enm.Lifebar != 0 && distance < nearestDistance)
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
    private float lifebar;

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