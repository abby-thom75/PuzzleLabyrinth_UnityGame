using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float range = 100f;
    public float damage = 25f;
    public Camera fpsCam;
    public ParticleSystem gunFlash; 

    public AudioClip soundFX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(soundFX, transform.position);
        gunFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Zombie"))
            {
                ZombieHealth zombie = hit.transform.GetComponent<ZombieHealth>();
                if (zombie != null)
                {
                    zombie.TakeDamage(damage);
                }
            }
        }
    }

}
