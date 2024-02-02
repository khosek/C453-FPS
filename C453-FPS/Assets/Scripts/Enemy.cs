using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    [SerializeField] private bool isPatrolling;
    [SerializeField] private Vector3[] patrolPoints;
    private int currentPatrolPoint = 0;
    private float shootCooldown = 5.0f;
    [SerializeField] private Weapon gun;
    [SerializeField] private ParticleSystem gunParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPatrolling)
        {
            agent.SetDestination(player.GetComponent<NavMeshAgent>().transform.position);

            shootCooldown -= Time.deltaTime;
            if(shootCooldown <= 0)
            {
                // gun.Shoot();
                gunParticles.Play();
                shootCooldown += 5.0f;
            }
        }
        else if (agent.remainingDistance < 1.0f)
        {
            currentPatrolPoint++;
            currentPatrolPoint %= patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolPoint]);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        isPatrolling = false;
    }

    public void Damage()
    {
        Destroy(this.gameObject);
    }
}
