using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChestKey : MonoBehaviour
{
    //once enter collider, add to HUD + amount (for HUD text)
    public GameObject HUD;
    public GameObject key;
    public TMP_Text amount;
    public AudioClip soundFX;

    private void OnTriggerEnter(Collider other)
    {
	 if (other.CompareTag("Player")) 
	{
		key.SetActive(false);
	        HUD.SetActive(true);
		AudioSource.PlayClipAtPoint(soundFX, transform.position);
        }
   }
	 
}
