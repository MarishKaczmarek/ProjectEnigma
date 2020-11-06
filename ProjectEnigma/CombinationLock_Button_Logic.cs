using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock_Button_Logic : InteractableObject
{
    //We need one function to add to our combination
    //We need one function for debug
    //We need one function to add our button we found earlier

    public CombinationLock_core.CombinationLockColors buttonType;

    private InventoryManager inventory;
    private CombinationLock_core cl;
    public string itemID;
    public GameObject yellowButton;

    public override void Start()
    {
        base.Start();
        inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null)
        {
            Debug.Log(inventory.gameObject.name + " is handling our Inventory");
        }

        else
        {
            Debug.Log("Inventory Manager not found!");
        }

        cl = GetComponentInParent<CombinationLock_core>();
        if(cl == null)
        {
            Debug.Log("Unable to find Combination Lock Core Logic.");
        }
    }

    public void ShowDebugInformation()
    {
        for(int i = 0; i < cl.correctCombination.Count; i++)
        {
            Debug.Log(cl.correctCombination[i]);
        }
    }

    public void AddMissingPiece()
    {
        //We need to check if the player has the correct object in their inventory and then remove it.
        bool foundObject = false;
        Debug.Log(inventory.inventory.Count);
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            Debug.Log(i);
            Debug.Log(inventory.inventory[i].itemID);

            if (inventory.inventory[i].itemID == itemID)
            {
                inventory.inventory.RemoveAt(i);
                foundObject = true;
            }
        }

        if(foundObject == true)
        {
            yellowButton.SetActive(true);
            Destroy(this);
        }

        else
        {
            Debug.Log("This is missing a piece");
        }
    }

    public void AddToCombination()
    {
        cl.attemptedCombination.Add(buttonType);

        string b;

        if (buttonType == CombinationLock_core.CombinationLockColors.button_green)
        {
            b = "G";
        }

        else if (buttonType == CombinationLock_core.CombinationLockColors.button_red)
        {
            b = "R";
        }

        else if (buttonType == CombinationLock_core.CombinationLockColors.button_yellow)
        {
            b = "Y";
        }

        else if (buttonType == CombinationLock_core.CombinationLockColors.button_purple)
        {
            b = "P";
        }

        else
        {
            b = "";
        }

        cl.combinationDisplayText.text = cl.combinationDisplayText.text + b;

        cl.CheckIfCorrect();
    }
}
