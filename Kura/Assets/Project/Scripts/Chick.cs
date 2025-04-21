using UnityEngine;
using UnityEngine.AI;

public class Chick : MonoBehaviour
{
    private ChickPool _chickPool;
    private Transform _player;
    NavMeshAgent agent;
    Animator playerAnim;    
    Counter counter;
    [SerializeField] ParticleSystem explosionParticle;    
    int pointValue = 1;

    public void Initialize(ChickPool chickPool, Transform player)
    {
        _chickPool = chickPool;
        _player = player;
        counter = GameObject.Find("Counter").GetComponent<Counter>();        
        agent = GetComponent<NavMeshAgent>();
        playerAnim = GetComponent<Animator>();        
    }    
    void Update()
    {       
        float distanse = Vector3.Distance(transform.position, _player.position);
        if (distanse >= 10)
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
        if (distanse < 10)
        {
            agent.SetDestination(_player.position);
            playerAnim.SetFloat("Speed_f", 1);
        }
        if (distanse <= 1)
        {
            agent.SetDestination(agent.transform.position);
            playerAnim.SetFloat("Speed_f", 0);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            //Destroy(gameObject);
            _chickPool.ReturnObject(this);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            counter.UpdateScore(pointValue);
        }        
    }   
}
