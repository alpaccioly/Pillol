using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {


	public Transform enemy;
	// Use this for initialization
	void Start () {
	
	}

	void Attack (Transform alvo) {
		GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"));
		go.transform.parent = transform.parent.parent;
		go.transform.localPosition = transform.localPosition;
		go.transform.localScale = Vector3.one;
		BulletBehaviour bala = go.GetComponent<BulletBehaviour>();
		bala.MoveTo (alvo.localPosition, this);
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
		if (Input.GetKeyDown("space")){
			if (enemy != null){
				Attack (enemy);
		}
	}
}
}