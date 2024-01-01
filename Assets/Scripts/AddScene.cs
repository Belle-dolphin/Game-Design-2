using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    // Name of the scene to be loaded additively
    public string sceneNameToAdd;

    private void OnMouseDown()
    {
        // Check if the scene is not already loaded
        if (!SceneManager.GetSceneByName(sceneNameToAdd).isLoaded)
        {
            // Load the scene additively
            SceneManager.LoadScene(sceneNameToAdd, LoadSceneMode.Additive);
        }
        else
        {
            // If already loaded, unload the scene
            SceneManager.UnloadSceneAsync(sceneNameToAdd);
        }
    }
}

