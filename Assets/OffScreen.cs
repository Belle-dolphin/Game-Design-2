using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OffScreen : MonoBehaviour
{
    public string sceneNameToAdd;
    Vector3 vectorMainMenu = Vector3.zero;

    int loaded = 0;

    private void OnMouseDown()
    {
        loaded++;
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
