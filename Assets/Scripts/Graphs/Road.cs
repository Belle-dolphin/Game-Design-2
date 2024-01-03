using UnityEngine;
using UnityEngine.UI;

public class Road : MonoBehaviour
{
    public Image targetImage; // Reference to the Image component you want to change the color of
    public bool state = false;
    public RoadValue value;
    public Counter valueCounter;
    public int id;
    public Solve solve;

    void Start()
    {
        // Change the color of the image to red at the start (you can set any color you want)
        ChangeColor(Color.white);
        state = false;
    }

    public void onClick(){

        if(state == false){
            enableRoad();
        }
        else{
            disableRoad();
        }
    }

    // Function to change the color of the image
    public void ChangeColor(Color newColor)
    {
        if (targetImage != null)
        {
            targetImage.color = newColor;
        }
    }

    public void enableRoad(){
            ChangeColor(Color.red);
            valueCounter.AddWeight(value.getWeight());
            solve.AddRoadID(id);
            state = true;
    }

    public void disableRoad(){
            ChangeColor(Color.white);
            valueCounter.SubtractWeight(value.getWeight());
            solve.RemoveRoadID(id);
            state = false;
    }
}
