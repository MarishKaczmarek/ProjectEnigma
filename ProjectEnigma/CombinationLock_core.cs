using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationLock_core : MonoBehaviour
{
    public enum CombinationLockColors {button_red, button_green, button_yellow, button_purple};

    //What do we need for this puzzle
    // - do we have a missing piece and so what is it?
    // - what is the correct combination of objects
    // - what combination did we pick
    // - how do we tell the player if they are on the right path?

    public List<CombinationLockColors> correctCombination;
    public List<CombinationLockColors> attemptedCombination;

    public int combinationSize = 4;

    public GameObject door;

    public Text combinationDisplayText;
    public Text guessDisplayText;
    public Text previousGuessesText;

    private void Start()
    {
        for (int i = 0; i < combinationSize; i++)
        {
            correctCombination.Add(GenerateCombination());
        }

        EnsureYellowIsIn();

        combinationDisplayText.text = "";
        previousGuessesText.text = "";
    }

    private void EnsureYellowIsIn()
    {
        for (int i = 0; i < correctCombination.Count; i++)
        {
            if(correctCombination[i] == CombinationLockColors.button_yellow)
            {
                Debug.Log("Algorithm already generated a yellow part of the combination");
                return;
            }
        }

        Debug.Log("Testing For Yellow");
        int r = Random.Range(1, combinationSize);
        correctCombination[r] = CombinationLockColors.button_yellow;
    }

    public void CheckIfCorrect()
    {
        //Fire only if the Count of the attempted combination is the same as the correct combination
        if(correctCombination.Count != attemptedCombination.Count)
        {
            return;
        }
        //First let's test if the combination is ACTUALLY correct
        Debug.Log("Checking if correct...");
        bool isCorrect = true;
        for (int i = 0; i < correctCombination.Count; i++)
        {
            if(correctCombination[i] != attemptedCombination[i])
            {
                isCorrect = false;
            }
        }

        if(isCorrect == false)
        {
            Debug.Log("Combination is incorrect");
            //We need to reset the attempted combination
            //We need to give feedback on how close we are to cracking the code.

            int correctColors = 0;

            for (int i = 0; i < attemptedCombination.Count; i++)
            {
                if(correctCombination[i] == attemptedCombination[i])
                {
                    correctColors++;
                }
            }

            Debug.Log("You have: " + correctColors + "/" + correctCombination.Count + " colors correct and in correct position");
            guessDisplayText.text = correctColors + "/" + correctCombination.Count + " correct";
            attemptedCombination.Clear();
            previousGuessesText.text = combinationDisplayText.text;
            combinationDisplayText.text = "";
        }

        else
        {
            Destroy(door);
        }
    }

    private CombinationLockColors GenerateCombination()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            return CombinationLockColors.button_green;
        }

        else if (r == 2)
        {
            return CombinationLockColors.button_purple;
        }

        else if (r == 3)
        {
            return CombinationLockColors.button_red;
        }

        else if (r == 4)
        {
            return CombinationLockColors.button_yellow;
        }

        else return CombinationLockColors.button_yellow;
    }
}
