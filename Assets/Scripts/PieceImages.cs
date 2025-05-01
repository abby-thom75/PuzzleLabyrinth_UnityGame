using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceImages : MonoBehaviour
{
   public GameObject pieceImage;
   public GameObject heldObj;
   private int LayerNumber;

   void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 
    }
    void Update()
    {
      if(heldObj.layer == LayerNumber)
	pieceImage.layer = LayerNumber;
      else
	pieceImage.layer = 0;
    }
}
