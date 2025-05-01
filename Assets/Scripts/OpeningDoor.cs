using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
   	//after switch lever, door opens
    public GameObject door;
    public GameObject openDoor;
    public GameObject lever;
    public GameObject clickLever;
    public AudioClip soundFX;

    private bool canInteract = false;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract)
	{
	     ClickLever();
	}
    }

    public void ClickLever()
    {
	lever.SetActive(false);
	clickLever.SetActive(true);
	OpenDoor();
    }
	
    public void OpenDoor()
    {
        door.SetActive(false);
	openDoor.SetActive(true);
	AudioSource.PlayClipAtPoint(soundFX, transform.position);
	canInteract = false;
    }

    private void OnTriggerEnter(Collider other)
    {
	if (other.CompareTag("Player"))
		canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
	if (other.CompareTag("Player"))
		canInteract = false;
    }
}
