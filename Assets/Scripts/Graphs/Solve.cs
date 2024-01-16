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
    public bool success = false;

    public string sceneNameToAdd;
    public string sceneNameToDelete;
    public int levelNumber;
    // public Button endLevelButton;

    private void Start()
    {
        // Add a listener to the button so that it calls LoadNextScene when clicked
        // endLevelButton.onClick.AddListener(onClick);
    }

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
        setSuccess(CompareRoadIDs());
        
        Debug.Log("Checking solution...");
        Debug.Log(CompareRoadIDs()
            ? "Road IDs match the solution"
            : "Road IDs do not match the solution");

        showResult(success);
    }

    private void setSuccess(bool state){
        Debug.Log("setSuccess called with: " + state);
        success = state;
    }

    private bool getSuccess(){
        Debug.Log("getSuccess called with: " + success);
        return success;
    }


    public void showResult(bool result){
        if(result){
            Debug.Log("Player won");
            ConditionText.SetText("You win!");
            ButtonText.SetText("Next Level");
            resultScreenObject.SetActive(true);
            Solve buttonScript = resultScreenObject.GetComponentInChildren<Solve>();
            if(buttonScript != null)
            {
                buttonScript.success = result;
            }
        } else {
            Debug.Log("Player lost");
            ConditionText.SetText("You lose!");
            ButtonText.SetText("Retry");
            resultScreenObject.SetActive(true);
            Solve buttonScript = resultScreenObject.GetComponentInChildren<Solve>();
            if(buttonScript != null)
            {
                buttonScript.success = result;
            }
        }
    }

    public void resetLevel(){
        PlayerPrefs.SetInt("TutorialGraphs", 1);
        PlayerPrefs.Save();
    }

    public void onClick(){
        Debug.Log("Player clicked");
        Debug.Log("Current value of success: " + getSuccess());
        if(getSuccess()){
            Debug.Log("Changing level");

            SceneManager.UnloadSceneAsync(sceneNameToDelete);
            SceneManager.LoadScene(sceneNameToAdd);
        } else {
            SceneManager.UnloadSceneAsync(sceneNameToDelete);
            SceneManager.LoadScene(sceneNameToDelete);
            // resetLevel();
        }
    }
}
