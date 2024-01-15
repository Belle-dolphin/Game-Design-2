using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlocksCounting : MonoBehaviour
{
    public int totalBlocks; // Set this to the total number of blocks
    private int correctBlocks = 0;
    public string sceneNameToAdd;
    public string sceneNameToDelete;
    public Button nextSceneButton;

    private void Start()
    {
        // Initially set the button to be inactive
        nextSceneButton.gameObject.SetActive(false);

        // Add a listener to the button so that it calls LoadNextScene when clicked
        nextSceneButton.onClick.AddListener(LoadNextScene);
    }

    public void SetBlockNum() 
    {  
        correctBlocks++;

        if (correctBlocks == totalBlocks)
        {
            // Activate the button
            nextSceneButton.gameObject.SetActive(true);
        }
    }

    public void LoadNextScene()
    {
        // Unload the current scene
        SceneManager.UnloadSceneAsync(sceneNameToDelete);

        // Load the next scene additively
        SceneManager.LoadScene(sceneNameToAdd, LoadSceneMode.Additive);
    }
}
