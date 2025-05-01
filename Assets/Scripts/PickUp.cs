using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public float pickUpRange = 5f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private int LayerNumber; 
    public Transform puzzleBoard;
 

    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
		{
                    if (hit.transform.gameObject.tag == "canPickUp")
                        PickUpObject(hit.transform.gameObject);
		}
            }
	    else
            {
                Collider[] nearbyObjects = Physics.OverlapSphere(heldObj.transform.position, 2f);
                foreach (Collider col in nearbyObjects)
                {
                    if (col.gameObject.tag == "PuzzleBoard")  
                    {
                        PlaceOnEasel();
                        return;
                    }
                }

                DropObject(); 
            }

        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;

	//offset to move to left hand (for gun)
	Transform holdOffset = heldObj.transform.Find("HoldOffset");
        if (holdOffset != null)
        {
            heldObj.transform.SetParent(holdPos);
            heldObj.transform.localPosition = holdOffset.localPosition;
            heldObj.transform.localRotation = holdOffset.localRotation;
        }
        else
        {
            heldObj.transform.SetParent(holdPos);
            heldObj.transform.localPosition = Vector3.zero;
            heldObj.transform.localRotation = Quaternion.identity;
        }

            heldObj.layer = LayerNumber; 
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
   void PlaceOnEasel()
    {
  	Transform correctSlot = puzzleBoard.Find(heldObj.name);
        if (correctSlot != null)
        {
            heldObj.transform.position = correctSlot.position;
            heldObj.transform.rotation = correctSlot.rotation;
            heldObj.transform.parent = puzzleBoard; 
            heldObjRb.isKinematic = true; 
            heldObj.tag = "PlacedPiece"; 
 	    heldObj.layer = 0; 
            heldObj = null; 

	   puzzleBoard.GetComponent<PuzzleManager>().PiecePlaced();
        }
    }
    void DropObject()
   {
    	 heldObj.transform.parent = null; 
   	 heldObjRb.isKinematic = false;  
   	 heldObj.layer = LayerMask.NameToLayer("Default"); 
   	 Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false); 
   	 heldObj = null; 
   }

}