using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        //Reset all local player data
        PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    public void Play() {
        Debug.Log("Play");
        //Load main scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit the game
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
