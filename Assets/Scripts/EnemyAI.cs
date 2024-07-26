using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public string playerGameObjectName;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float attackSpeed;
    public bool hasAttacked;
    public GameObject projectile;

    //states
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

    public void Awake()
    {
        player = GameObject.Find(playerGameObjectName).transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        //check for sight and attack range
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSight && !playerInAttackRange) Patrolling();
        if (playerInSight && !playerInAttackRange) Chase();
        if (playerInSight && playerInAttackRange) Attack();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalk = transform.position - walkPoint;

        if( distanceToWalk.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //calculate a random spot to walk to
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y ,transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))//sends a ray under the enemy to see if there is ground where they would walk to, if so set walkpointset = true
        {
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack() {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!hasAttacked)
        {
            //attack code here

            Rigidbody rb = Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackSpeed);
        }
    }


    private void ResetAttack()
    {
        hasAttacked = false;


    }
}
