using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OffScreen : MonoBehaviour
{
    public string sceneNameToAdd;
    public int nrPuzzels;
    Vector3 vectorMainMenu = Vector3.zero;

    int loaded = 0;
    int changed = 0;

    private void OnMouseDown()
    {
        loaded++;

        // scene changed
        if (sceneNameToAdd.Contains("Programming problem"))
        {
            if (SceneManager.GetSceneByName("Programming problem 1").isLoaded)
            {
                sceneNameToAdd = "Programming problem 1";
            }
            else if (SceneManager.GetSceneByName("Programming problem 2").isLoaded)
            {
                sceneNameToAdd = "Programming problem 2";
            }
            else if (SceneManager.GetSceneByName("Programming problem 3").isLoaded)
            {
                sceneNameToAdd = "Programming problem 3";
            }
            else if (SceneManager.GetSceneByName("Programming problem 4").isLoaded)
            {
                sceneNameToAdd = "Programming problem 4";
            }
            else if (SceneManager.GetSceneByName("Programming problem 5").isLoaded)
            {
                sceneNameToAdd = "Programming problem 5";
            }
        } 
        else if (sceneNameToAdd.Contains("Graphs puzzle"))
        {
            if (SceneManager.GetSceneByName("Graphs puzzle_1 tutorial").isLoaded)
            {
                sceneNameToAdd = "Graphs puzzle_1 tutorial";
            }
            else if (SceneManager.GetSceneByName("Graphs puzzle_2").isLoaded)
            {
                sceneNameToAdd = "Graphs puzzle_2";
            }
            else if (SceneManager.GetSceneByName("Graphs puzzle_3").isLoaded)
            {
                sceneNameToAdd = "Graphs puzzle_3";
            }
            else if (SceneManager.GetSceneByName("Graphs puzzle_4").isLoaded)
            {
                sceneNameToAdd = "Graphs puzzle_4";
            }
        }
        

        UnityEngine.SceneManagement.Scene loadedScene = SceneManager.GetSceneByName(sceneNameToAdd);
        GameObject mainMenuObject = GameObject.Find("MainMenu");
        
        if (loaded == 1)
        {
            vectorMainMenu = mainMenuObject.transform.localPosition;
        }

        if (loadedScene.isLoaded && mainMenuObject != null)
        {
            if (loaded % 2 == 1)
            {
                RectTransform canvasRectTransform = loadedScene.GetRootGameObjects()[0].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
                mainMenuObject.transform.SetParent(canvasRectTransform);
                mainMenuObject.transform.localPosition = new Vector3(-9999f, mainMenuObject.transform.localPosition.y, mainMenuObject.transform.localPosition.z);
            }
            else if (loaded % 2 == 0) 
            {
                RectTransform canvasRectTransform = loadedScene.GetRootGameObjects()[0].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
                mainMenuObject.transform.SetParent(canvasRectTransform);
                mainMenuObject.transform.localPosition = vectorMainMenu;
            }
        }
    }
}
