using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlocksCounting : MonoBehaviour
{
    public int totalBlocks; // Set this to the total number of blocks
    private int correctBlocks = 0;
    public string sceneNameToAdd;

    public void SetBlockNum() 
    {  
        correctBlocks++;

        if (correctBlocks == totalBlocks)
        {
            // Load the next scene
            SceneManager.LoadScene(sceneNameToAdd); // Replace "NextScene" with the name of your next scene
        }
    }
}
