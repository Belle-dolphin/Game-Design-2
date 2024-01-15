using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OffScreen : MonoBehaviour
{
    public string sceneNameToAdd;
    Vector3 vectorMainMenu = Vector3.zero;

    int loaded = 0;
    int changed = 0;
    int nrPuzzels = 5; // puzzels to solve TODO make public.

    private void OnMouseDown()
    {
        loaded++;

        if (!SceneManager.GetSceneByName(sceneNameToAdd).isLoaded)
        {
            // scene changed
            changed++;
            if (sceneNameToAdd.Contains("Programming problem"))
            {
                if (changed % nrPuzzels == 1)
                {
                    sceneNameToAdd = "Programming problem 2";
                }
                else if (changed % nrPuzzels == 2)
                {
                    sceneNameToAdd = "Programming problem 3";
                }
                else if (changed % nrPuzzels == 3)
                {
                    sceneNameToAdd = "Programming problem 4";
                }
                else if (changed % nrPuzzels == 4)
                {
                    sceneNameToAdd = "Programming problem 5";
                }
                else if (changed % nrPuzzels == 0) { sceneNameToAdd = "Programming problem 1"; }
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
