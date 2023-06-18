using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntlerBoiAi : MonoBehaviour
{
    public NavMeshAgent antlerBoi;

    public Transform scaredPlayer;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling

    public Vector3 walkPoint;

    bool walkPointSet;
    public float walkPointRange;

    //Atacking

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject rootAttack;

    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //audio
    public AudioSource monsterCallSource;
    public AudioClip monsterCallClip;
    bool playedMonsterCall;

    public AudioSource throwSource;
    public AudioClip throwClip;


    private void Awake()
    {
        scaredPlayer = GameObject.Find("PlayerControllerFPS").transform;
        antlerBoi = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sighht and attack range

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            playedMonsterCall = false;
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if (playerInAttackRange && !playedMonsterCall)
        {
            monsterCallSource.Play();
            playedMonsterCall = true;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            antlerBoi.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        antlerBoi.SetDestination(scaredPlayer.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        antlerBoi.SetDestination(transform.position);

        transform.LookAt(scaredPlayer);

        if (!alreadyAttacked)
        {
            //Attack code here

            Rigidbody rb = Instantiate(rootAttack, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
            rb.AddForce(transform.up * 3f, ForceMode.Impulse);
            throwSource.Play();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}