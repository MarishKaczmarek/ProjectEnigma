using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOfHanoi_Tower : InteractableObject
{
    public List<GameObject> pieces;
    public Transform hoverLocation;
    public Transform slot3;
    public Transform slot2;
    public Transform slot1;
    public Transform slot0;
    public TowerOfHanoi_Logic toh;

    public void MovePiece()
    {
        Debug.Log("Moving piece from " + gameObject.name);
        if (toh.holdingPiece == null)
        {
            int i = pieces.Count - 1;
            toh.holdingPiece = pieces[i];
            pieces.RemoveAt(i);
            toh.holdingPiece.transform.position = hoverLocation.position;
        }

        else
        {
            //We need to determine if we can place the object.
            int i = pieces.Count - 1;
            string name;
            
            if (i < 0)
            {
                //In case the array is out of index
                name = "";
            }

            else
            {
                Debug.Log("Is this being fired properly?");
                name = pieces[i].name;
            }

            Debug.Log("Holding " + toh.holdingPiece.name);
            Debug.Log("Trying to place on top of " + name);

            if (toh.holdingPiece.name == "Hanoi_Tiny")
            {
                PlacePiece();   
            }

            else if (toh.holdingPiece.name == "Hanoi_Small")
            {
                if(name == "Hanoi_Tiny")
                {
                    Debug.Log("We can't place on top of tiny");
                    toh.lt.TriggerLight();
                }

                else
                {
                    PlacePiece();
                }
            }

            else if (toh.holdingPiece.name == "Hanoi_Medium")
            {
                if(name == "Hanoi_Small" || name == "Hanoi_Tiny")
                {
                    Debug.Log("We can't place on top of tiny or small");
                    toh.lt.TriggerLight();
                }

                else
                {
                    PlacePiece();
                }
            }

            else if (toh.holdingPiece.name == "Hanoi_Large")
            {
                if(name == "Hanoi_Medium" || name == "Hanoi_Small" || name == "Hanoi_Tiny")
                {
                    Debug.Log("We can't place on top of tiny, small or medium");
                    toh.lt.TriggerLight();
                }

                else
                {
                    PlacePiece();
                }
            }
            
        }
    }

    private void PlacePiece()
    {
        pieces.Add(toh.holdingPiece);
        toh.holdingPiece = null;
        int i = pieces.Count - 1;
        pieces[i].transform.position = DetermineLocation(i);
    }

    public void CheckOrder()
    {
        if(pieces.Count == 4)
        {
            if(pieces[0].name == "Hanoi_Large")
            {
                if(pieces[1].name == "Hanoi_Medium")
                {
                    if(pieces[2].name == "Hanoi_Small")
                    {
                        if(pieces[3].name == "Hanoi_Tiny")
                        {
                            toh.OpenDoor();
                        }
                    }
                }
            }
        }

        else
        {
            Debug.Log("Not enough pieces");
        }
    }

    private Vector3 DetermineLocation(int location)
    {
        if (location == 0)
        {
            return slot0.position;
        }

        else if (location == 1)
        {
            return slot1.position;
        }

        else if (location == 2)
        {
            return slot2.position;
        }

        else if (location == 3)
        {
            return slot3.position;
        }

        else
        {
            Debug.Log("WE BROKE THE GAME");
            return new Vector3(0, 0, 0);
        }
    }
}
