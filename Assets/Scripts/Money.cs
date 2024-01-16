using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int multiplier = 1; // Set this to your multiplier
    public TMP_Text moneyText; // Assign this in the inspector

    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int money = (int)(elapsedTime * multiplier);
        moneyText.text = "Money: €" + money.ToString();
    }
}
