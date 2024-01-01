using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    // Name of the scene to be loaded additively
    public string sceneNameToAdd;
    public GameObject taskbarIconPrefab;
    int loaded = 0;

    private void OnMouseDown()
    {
        // Check if the scene is not already loaded
        if (!SceneManager.GetSceneByName(sceneNameToAdd).isLoaded)
        {
            loaded++;
            // Load the scene additively
            SceneManager.LoadScene(sceneNameToAdd, LoadSceneMode.Additive);

            // Instantiate the taskbarIcon prefab
            GameObject taskbarIconInstance = Instantiate(taskbarIconPrefab, new Vector3(-4.45f, -4.75f, 0f), Quaternion.identity);
        }
        else
        {
            // If already loaded, move the scene offscreen by changing the z-coordinate to 5
            Scene loadedScene = SceneManager.GetSceneByName(sceneNameToAdd);
            if (loadedScene.isLoaded)
            {
                GameObject[] rootObjects = loadedScene.GetRootGameObjects();
                foreach (GameObject obj in rootObjects)
                {
                    obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 5f);
                }
            }
        }
    }
}
