using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad_Logic : MonoBehaviour
{
    public enum KeyPadButton { k1, k2, k3, k4, k5, k6, k7, k8, k9 };

    public List<KeyPadButton> combination;
    public List<KeyPadButton> attemptedCombination;

    public Text displayText;

    public GameObject doorObject;

    private bool isSolved = false;

    public void EvaluateCombination()
    {
        if (isSolved == false)
        {
            if (attemptedCombination.Count >= combination.Count)
            {
                Debug.Log("Evaluating Combination");

                bool combinationIsCorrect = true;

                for (int i = 0; i < combination.Count; i++)
                {
                    if (combination[i] != attemptedCombination[i])
                    {
                        Debug.Log("Combination is not correct");
                        combinationIsCorrect = false;
                    }
                }

                if (combinationIsCorrect == true)
                {
                    Debug.Log("WE GOT THE RIGHT COMBINATION");
                    doorObject.SetActive(false);
                    displayText.text = "SOLVED";
                    isSolved = true;
                }

                else if (combinationIsCorrect == false)
                {
                    Debug.Log("Nope...");
                    displayText.text = "";
                }

                attemptedCombination.Clear();
            }
        }
    }
}
