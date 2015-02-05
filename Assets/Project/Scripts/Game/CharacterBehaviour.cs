using UnityEngine;
using System.Collections;
using Board;
using System.Collections.Generic;

public class CharacterBehaviour : MonoBehaviour {

	public int TeamNumber;
	public Transform enemy;
	private Transform firePointTr;
	private BoardBehaviour board;
	// Use this for initialization
	void Awake () {
		firePointTr = transform.Find ("FirePoint");
		board = transform.parent.GetComponent<BoardBehaviour>();
	}
	void Start () {
	
	}
	void Attack (Transform alvo) {
		GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"));
		go.transform.parent = transform.parent.parent;
		Debug.Log (go.transform.parent);
		go.transform.localPosition = firePointTr.localPosition + this.transform.localPosition;
		Debug.Log (go.transform.localPosition);
		go.transform.localScale = Vector3.one;
		BulletBehaviour bala = go.GetComponent<BulletBehaviour>();
		bala.Chr = this;
		bala.Position = go.transform.localPosition;
		bala.MoveTo (alvo.localPosition);

	}
		Transform FindEnemy () {
			Transform nearest = null;
			List<CharacterBehaviour> team = board.GetTeam ((TeamNumber + 1) % 2);
			foreach (CharacterBehaviour enm in team) {
				Vector3 enemyPosition = enm.transform.localPosition;
				Vector3 myPosition = this.transform.localPosition;
				if (enm.Lifebar != 0) {
						if (nearest == null || Vector3.Distance (myPosition, enemyPosition) <= Vector3.Distance (myPosition, nearest.localPosition)) {
								nearest = enm.transform;
						}
				} 
			}
			return nearest;
		}
		
	public void Hit (float damage) {
		lifebar = Mathf.Max (lifebar - damage, 0f);
	}
	private float lifebar;

	public float Lifebar{
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
	void Update () {
		//Alterar para atacar o inimigo 
		if (Input.GetKeyDown("space")){
			if (enemy != null){
				Attack (enemy);
		}
	}
}
}