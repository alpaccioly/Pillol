using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Board;

public class GlobalLifebarBehaviour : MonoBehaviour {
	private float health;
	private float maxHealth;
	//public int TeamNo;
	private int maxMembers;
	private GameObject go;
	private BoardBehaviour board;
	private Transform barra;
	private Vector3 barraSize;
	private Vector3 targetSize;
	private float lifeRatio;
	//private List<CharacterBehaviour> team;

	// Use this for initialization
	void Awake () {
		go = transform.parent.parent.gameObject;
		board = go.GetComponent<BoardBehaviour> ();
		maxMembers = board.membersPerTeam;
		health = maxMembers * 1000f;
		maxHealth = health;
		barra = transform.FindChild("Bar");
		barraSize = barra.localScale;
		targetSize = barraSize;
		targetSize.x = 0.0f;
		barra.renderer.material.color = Color.green;
	}
	void Start () {
		
	}
	public void Lower (float amount){
		health = Mathf.Max (health - amount, 0f);
		lifeRatio = health / maxHealth;
		barra.localScale = Vector3.Lerp (targetSize, barraSize, lifeRatio);
		barra.renderer.material.color = Color.Lerp(Color.red, Color.green, lifeRatio);
	}
	// Update is called once per frame
	void Update () {

	}
}