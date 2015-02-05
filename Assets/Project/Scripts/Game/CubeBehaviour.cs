using UnityEngine;
using System.Collections;
using Board;

public class CubeBehaviour : MonoBehaviour {

	public BoardBehaviour BoardScript; 

	void Awake()
	{
		BoardScript = transform.parent.parent.GetComponent<BoardBehaviour> ();
	}
	// Update is called once per frame
	void Update () {
		//PointBoard p = (PointBoard)BoardScript.GetPositionBoard (transform.localPosition);
		//Debug.Log (string.Format("{0}, {1}",p.I, p.J));
		       
	}
}
