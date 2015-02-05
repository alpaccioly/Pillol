using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	public int TeamNumber;
	public Transform enemy;
	private Transform firePointTr;
	// Use this for initialization
	void Awake () {
		firePointTr = transform.Find ("FirePoint");
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
	CharacterBehaviour FindEnemy () {
		//todo
		return this;
	}

	public void Hit (double damage) {
		lifebar = lifebar - damage;
	}
	private double lifebar;

	public double Lifebar{
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