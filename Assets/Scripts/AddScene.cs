using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    public string sceneNameToAdd;
    public GameObject taskbarIcon;

    bool iconLoaded = false;

    private void OnMouseDown()
    {
        // Check if the scene is not already loaded
        if (!SceneManager.GetSceneByName(sceneNameToAdd).isLoaded)
        {
            // Load the scene additively
            SceneManager.LoadScene(sceneNameToAdd, LoadSceneMode.Additive);

            if (!iconLoaded)
            {
                Instantiate(taskbarIcon, new Vector3(-4.45f, -4.75f, 0f), Quaternion.identity);
                iconLoaded = true;
            }
        }
    }
 
}
