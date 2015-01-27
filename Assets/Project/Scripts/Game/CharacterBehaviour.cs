using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Attack (Transform alvo) {
		GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"));
		go.transform.parent = transform.parent.parent;
		transform.localPosition = Vector3.zero;
		transform.localScale = Vector3.one;
		BulletBehaviour bala = go.GetComponent<BulletBehaviour>();
		bala.MoveTo (alvo.position);
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
	
	}
}
