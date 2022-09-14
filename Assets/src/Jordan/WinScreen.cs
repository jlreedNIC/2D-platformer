using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    GameObject winScreen;
    public static GameObject winChild;

    // Start is called before the first frame update
    void Start()
    {
        winScreen = GameObject.Find("WinScreen");
        winChild = winScreen.transform.GetChild(0).gameObject;
        winChild.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void win()
    {
        Time.timeScale = 0f; 
        winChild.SetActive(true);
        // GameManager.HideOverlay();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    // quits the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
