using UnityEngine;
using System.Collections;
using Board;

public class TimerBehaviour : MonoBehaviour
{
    private float tempo = 5.0f;
    private int tempoInt;
    private TextMesh txt;
    void Awake()
    {
        txt = this.GetComponent <TextMesh>();
    }
    void Start()
    {
	
    }
    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        tempoInt = (int)Mathf.Ceil(tempo);
        if (tempoInt == 0)
        {
            transform.parent.parent.parent.GetComponent<BoardBehaviour>().Init();
            Destroy(gameObject);
        }
        txt.text = tempoInt.ToString();
    }
   
}
