using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject gun;
    public GameObject heldGun;
    public AudioClip soundFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gun.SetActive(false);
	    heldGun.SetActive(true);
	    AudioSource.PlayClipAtPoint(soundFX, transform.position);
          
        }
   }

}
