using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public int TotalWeight;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        TotalWeight = 0;
        UpdateValue(TotalWeight);
    }


    public void AddWeight(int weight)
    {
        TotalWeight += weight;
        UpdateValue(TotalWeight);
    }

    public void SubtractWeight(int weight)
    {
        TotalWeight -= weight;
        UpdateValue(TotalWeight);
    }


    public int getWeight()
    {
        return TotalWeight;
    }

    //Call if dead
    public void ResetWeight()
    {
        TotalWeight = 0;
        UpdateValue(TotalWeight);
    }

    private void UpdateValue(int val){
        text.SetText("Total : " + val);
    }
}
