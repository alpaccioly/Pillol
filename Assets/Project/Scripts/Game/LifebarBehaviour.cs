using UnityEngine;
using System.Collections;

public class LifebarBehaviour : MonoBehaviour {
    CharacterBehaviour cb;
    private int life;
    TextMesh txt;
	// Use this for initialization
    void Awake () {
        Transform pai = transform.parent;
        cb = pai.GetComponent<CharacterBehaviour>();
        life = (int) Mathf.Ceil(cb.Lifebar);
        txt = this.GetComponent<TextMesh>();
    }
	void Start () {

	}
	// Update is called once per frame
	void Update () {
        life = (int) Mathf.Ceil(cb.Lifebar);
        txt.text = life.ToString();
	}
}
