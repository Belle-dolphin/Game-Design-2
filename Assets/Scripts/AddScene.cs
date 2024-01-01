using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    public string sceneNameToAdd;
    public GameObject taskbarIcon;

    bool iconLoaded = false;
    Vector3 vectorMainMenu = Vector3.zero;

    int loaded = 0;

    private void OnMouseDown()
    {
        loaded++;
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
        else
        {

            Scene loadedScene = SceneManager.GetSceneByName(sceneNameToAdd);

            GameObject mainMenuObject = GameObject.Find("MainMenu"); // Assuming the GameObject is named "MainMenu"
            if (loaded == 2)
            {
                vectorMainMenu = new Vector3(mainMenuObject.transform.localPosition.x, mainMenuObject.transform.localPosition.y, mainMenuObject.transform.localPosition.z);

            }

            if (loaded % 2 == 0)
            {
                RectTransform canvasRectTransform = loadedScene.GetRootGameObjects()[0].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
                mainMenuObject.transform.SetParent(canvasRectTransform);
                mainMenuObject.transform.localPosition = new Vector3(-9999f, mainMenuObject.transform.localPosition.y, mainMenuObject.transform.localPosition.z);
            }

            if (loaded % 2 == 1)
            {
                RectTransform canvasRectTransform = loadedScene.GetRootGameObjects()[0].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
                mainMenuObject.transform.SetParent(canvasRectTransform);
                mainMenuObject.transform.localPosition = vectorMainMenu;
            }



        }
    }
}