using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	private Vector3 position, target;
	private float speed = 5f;
	private float h = 3.0f;
	private double damage; //CALCULAR DE ACORDO COM PROPRIEDADES
	private float tmax;
	private bool strt;
	private float t;
	private CharacterBehaviour chr;

	// Use this for initialization
	void Awake () {
		t = 0.0f;
	}
	void Start () {
	
	}
	public void MoveTo (Vector3 posicaoAlvo, CharacterBehaviour charBehaviour){
		chr = charBehaviour;
		target = posicaoAlvo;
		float d = Vector3.Distance (position, target);
		tmax = d / speed;
		Debug.Log (d);
		Debug.Log (tmax);
		strt = true;
	}
	void ChangePosition (float t){
		if (t >= 0 && t < 1) {
						position = (1 - t) * position + t * target;
						position.y = 4 * h * (t - t * t);
						Debug.Log (position);
						transform.localPosition = position;
				}
	}
	void OnTriggerEnter (Collider col){
		Debug.Log ("Colidiu");
		CharacterBehaviour ch = col.transform.GetComponent<CharacterBehaviour>();
		if (ch != null && ch != chr){
				ch.Hit (damage);
				Destroy (gameObject);
			}
	}
	
	// Update is called once per frame
	void Update () {
		if (strt) {
			t = t + Time.deltaTime;
			ChangePosition(t/tmax);	
		}
	
	}
}
