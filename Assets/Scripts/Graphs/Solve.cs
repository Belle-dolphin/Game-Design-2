using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Solve : MonoBehaviour
{
    // List to store road IDs
    private List<int> roadIDs = new List<int>();

    // List for the solution (editable in the inspector)
    [SerializeField]
    private List<int> solution = new List<int>();

    public GameObject resultScreenObject;
    public TextMeshProUGUI ConditionText;
    public TextMeshProUGUI ButtonText;
    private bool success = false;

    // Function to compare road IDs with the solution
    public bool CompareRoadIDs()
    {
        roadIDs.Sort();
        solution.Sort();

        if (roadIDs.Count != solution.Count)
        {
            Debug.Log("Road IDs count does not match solution count");
            return false;
        }

        for (int i = 0; i < roadIDs.Count; i++)
        {
            if (roadIDs[i] != solution[i])
            {
                Debug.Log("Road ID at index " + i + " does not match the solution");
                return false;
            }
        }

        Debug.Log("Road IDs match the solution");
        return true;
    }

    // Sorting roadIDs list
    public void SortRoadIDs()
    {
        roadIDs.Sort();
        Debug.Log("Road IDs sorted");
    }

    public void AddRoadID(int roadID)
    {
        roadIDs.Add(roadID);
        Debug.Log("Road ID added: " + roadID);
    }

    public void RemoveRoadID(int roadID)
    {
        if (roadIDs.Contains(roadID))
        {
            roadIDs.Remove(roadID);
            Debug.Log("Road ID removed: " + roadID);
        }
        else
        {
            Debug.Log("Road ID " + roadID + " not found in the list.");
        }
    }

    public void CheckSolution()
    {
        success = CompareRoadIDs();
        
        Debug.Log("Checking solution...");
        Debug.Log(CompareRoadIDs()
            ? "Road IDs match the solution"
            : "Road IDs do not match the solution");

        showResult(success);
    }


    public void showResult(bool result){
        if(result){
            Debug.Log("Player won");
            ConditionText.SetText("You win!");
            ButtonText.SetText("Next Level");
            resultScreenObject.SetActive(true);
        } else {
            Debug.Log("Player lost");
            ConditionText.SetText("You lose!");
            ButtonText.SetText("Retry");
            resultScreenObject.SetActive(true);
        }
    }

    public void resetLevel(){
        PlayerPrefs.SetInt("TutorialGraphs", 1);
        PlayerPrefs.Save();
    }

    public void onClick(){
        Debug.Log("Player clicked");
        Debug.Log("Current value of success: " + success);
        if(success){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            resetLevel();
        }
    }

}
