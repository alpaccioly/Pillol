using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	private Vector3 position, target;
	private float speed = 5.0f;
	private float h = 3.0f;
	private double damage; //CALCULAR DE ACORDO COM PROPRIEDADES
	private float tmax;
	private bool strt;
	private float t;

	// Use this for initialization
	void Awake () {
		t = 0.0f;
	}
	void Start () {
	
	}
	public void MoveTo (Vector3 posicaoAlvo){
		target = posicaoAlvo;
		float d = Vector3.Distance (position, target);
		tmax = d / speed;
		strt = true;
	}
	void ChangePosition (float t){
		position = (1 - t) * position + t * target;
		position.z = 4 * h * (t - Mathf.Pow (t, 2));
	}
	void OnTriggerEnter (Collider col){
		Debug.Log ("Colidiu");
		CharacterBehaviour ch = col.transform.GetComponent<CharacterBehaviour>();
		ch.Hit (damage);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (strt) {
			t = t + Time.deltaTime;
			ChangePosition(t/tmax);	
		}
	
	}
}
