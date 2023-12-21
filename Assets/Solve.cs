using UnityEngine;
using System;
using System.Collections.Generic;

public class Solve : MonoBehaviour
{
    // List to store road IDs
    private List<int> roadIDs = new List<int>();

    // List for the solution (editable in the inspector)
    [SerializeField]
    private List<int> solution = new List<int>();

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
        if (CompareRoadIDs())
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }
    }
}
