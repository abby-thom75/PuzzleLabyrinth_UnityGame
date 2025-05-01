using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
   public float health = 100f;
   public AudioClip hurtFX;
   public AudioClip dieFX;
   public Animator animator;

    public void TakeDamage(float amount)
    {

        health -= amount;
        AudioSource.PlayClipAtPoint(hurtFX, transform.position);
        animator.SetTrigger("Hurt");


        if (health <= 0f)
	{
            Die();
	}
    }

    void Die()
    {

        AudioSource.PlayClipAtPoint(dieFX, transform.position);
        animator.SetTrigger("Die");
        animator.SetFloat("Speed", 0f);

	//freeze zombie
    	GetComponent<ZombieAi>().enabled = false;
    	GetComponent<Collider>().enabled = false;
    	GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

    }

   public void DestroyZombie()
   {
      Destroy(gameObject);
   }

}
