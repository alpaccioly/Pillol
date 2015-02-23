using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{
    public CharacterBehaviour Chr;
    public Vector3 Position;
    private Vector3 target;

    // Arma do atirador
    public float Aa;
    // Habilidade do jogador
    public float Aj;
    // Distancia do jogador ate o alvo
    public float Rj;

    private float speed = 180f;
    private float h = 60.0f;
    private float d;
    private bool strt;
    private float t;

    private const float maximumBulletLife = 10f;
    private float currentBulletLife = 0f;

    // Use this for initialization
    void Awake()
    {

    }
    void Start()
    {
        t = Time.time;
    }
    public void MoveTo(Vector3 posicaoAlvo, float weaponPower, float attackPower)
    {
        target = posicaoAlvo;
        d = Vector3.Distance(Position, target);
        Rj = d;
        Aa = weaponPower;
        Aj = attackPower;
        strt = true;
    }
    void ChangePosition(float Tm)
    {
        float distCovered = (Tm - t) * speed;
        float fracJourney = distCovered / d;
        Vector3 v = Vector3.Lerp(Position, target, fracJourney);
		if (v.Equals(target))
		{
			Destroy(gameObject);
			return;
		}
        transform.localPosition = new Vector3(v.x, v.y - 4.0f * h * ((fracJourney * fracJourney) - fracJourney), v.z);
    }

    private bool didHit()
    {
        const float c = 2f , p1= 1f , p2= 1f;
        float rand = Random.Range(0f, 1f);
        float p = c * Aj * Aj * Mathf.Sqrt(Aa * p1 - (1f / Rj) * p2);
        return rand < p;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colidiu");
        CharacterBehaviour ch = col.transform.GetComponent<CharacterBehaviour>();
        if (ch != null && ch != Chr && ch.TeamNumber != Chr.TeamNumber)
        {
            if (didHit())
                ch.triggerHit(this);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentBulletLife += Time.deltaTime;
        if (currentBulletLife >= maximumBulletLife)
            Destroy(gameObject);

        if (strt)
        {
            ChangePosition(Time.time);
        }
	
    }
}
