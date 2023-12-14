using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    public GameObject[] popups;
    private int popUpIndex;

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < popups.Length; i++)
        {
            if (i == popUpIndex)
            {
                popups[i].SetActive(true);
            }
            else
            {
                popups[i].SetActive(false);
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
