using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;
    public GameObject openedChest;
    public GameObject key;
    private bool hasKey;
    public AudioClip soundFX;
 
    
    void Update()
    {
	if (key.activeInHierarchy)
	  hasKey = true;
    }

     private void OnTriggerEnter(Collider other)
     {
	if (other.CompareTag("Player") && hasKey)
	{
	     AudioSource.PlayClipAtPoint(soundFX, transform.position);
             chest.SetActive(false);
	     openedChest.SetActive(true); 
	     key.SetActive(false);
	}
     }

}
