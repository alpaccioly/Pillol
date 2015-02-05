using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{
    public Vector3 Position;
    private Vector3 target;
    private float speed = 20f;
    private float h = 3.0f;
    private float d;
    private float damage; //CALCULAR DE ACORDO COM PROPRIEDADES
    private bool strt;
    private float t;
    public CharacterBehaviour Chr;

    // Use this for initialization
    void Awake()
    {

    }
    void Start()
    {
        t = Time.time;
        Debug.Log(t);
    }
    public void MoveTo(Vector3 posicaoAlvo)
    {
        target = posicaoAlvo;
        Debug.Log(target);
        d = Vector3.Distance(Position, target);
        strt = true;
    }
    void ChangePosition(float Tm)
    {
        float distCovered = (Tm - t) * speed;
        float fracJourney = distCovered / d;
        Vector3 v = Vector3.Lerp(Position, target, fracJourney);
        transform.localPosition = new Vector3(v.x, v.y - 4.0f * h * ((fracJourney * fracJourney) - fracJourney), v.z);

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colidiu");
        Debug.Log(col.transform.name);
        CharacterBehaviour ch = col.transform.GetComponent<CharacterBehaviour>();
        if (ch != null && ch != Chr && ch.TeamNumber != Chr.TeamNumber)
        {
            ch.Hit(damage);
            Destroy(gameObject);
            Debug.Log(Time.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (strt)
        {
            ChangePosition(Time.time);
        }
	
    }
}
