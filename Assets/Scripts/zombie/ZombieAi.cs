using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent zombie;
    public Animator animator;
    public float detectionRadius = 10f;
    public Transform player;

    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float lastAttackTime = 0f;
    public int damage = 10;


    void Start()
    {
        zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zombie.stoppingDistance = 4f;
    }

    void Update()
    {
	animator.SetFloat("Speed", zombie.velocity.magnitude);

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer <= detectionRadius)
        {
            zombie.isStopped = false;
	    zombie.SetDestination(player.position);

    	    if (distToPlayer <= attackRange && Time.time >= lastAttackTime)
    	    {
        	animator.SetTrigger("Attack");
        	lastAttackTime = Time.time + attackCooldown;
    	    }
        }
        else
        {
            zombie.isStopped = true;
            animator.SetFloat("Speed", 0f);
        }
    }


    void AttackPlayer()
   {
      PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
      playerHealth.TakeDamage(damage);
   }

}
