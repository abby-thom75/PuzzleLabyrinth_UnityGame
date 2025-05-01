using System.Collections;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public int totalPieces = 6;
    private int placedPieces = 0;
    public GameObject door;
    public GameObject openDoor;
    public GameObject piecesUI;
    public int amount;
    public TMP_Text amountText;

    public void PiecePlaced()
    {
        placedPieces++;
	UpdateHUD(placedPieces);

        if (placedPieces >= totalPieces) 
        {
	    Debug.Log("puzzle completed");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
       door.SetActive(false);
	openDoor.SetActive(true);
    }

   public void UpdateHUD(int amount)
   {
     if(amount == 1)
	{
	    piecesUI.SetActive(true);
	    amountText.text = $"x {amount} /6";
	}
      else
	{
	   amountText.text = $"x {amount} /6";
	}
	
   }
   

}