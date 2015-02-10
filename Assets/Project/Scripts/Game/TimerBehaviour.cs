using UnityEngine;
using System.Collections;

public class TimerBehaviour : MonoBehaviour {

    private float tempo = 5.0f;
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        tempo -= Time.deltaTime;
        if (tempo <= 0)
        {
           // Destroy(this);
        }
	}
   
}
