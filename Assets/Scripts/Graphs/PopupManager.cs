using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    public GameObject[] popups;
    public GameObject background;
    private int popUpIndex;

    void Start()
    {
        Debug.LogWarning("TutorialGraphs is " + PlayerPrefs.GetInt("TutorialGraphs"));
        if(PlayerPrefs.GetInt("TutorialGraphs") != 1){
            background.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("TutorialGraphs") != 1){
            
            for (int i = 0; i < popups.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popups[i].SetActive(true);
                }
                else
                {
                    popups[i].SetActive(false);
                    if (popUpIndex >= 4)
                    {
                        background.SetActive(false);
                    }
                }
            }

            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space)){
                    popUpIndex++;
                }
            } else if (popUpIndex == 1) {
                if (Input.GetKeyDown(KeyCode.Space)){
                    popUpIndex++;
                }
            } else if (popUpIndex == 2) {
                if (Input.GetKeyDown(KeyCode.Space)){
                    popUpIndex++;
                }
            }
        }
    }
}
