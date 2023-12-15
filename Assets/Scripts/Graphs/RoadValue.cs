using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoadValue : MonoBehaviour
{
    public int weight;
    //create variable for text mesh pro
    [SerializeField]
    private TextMeshProUGUI RoadText;

    void Start()
    {
        RoadText.text = weight + "";
    }

    public int getWeight()
    {
        return weight;
    }
}
