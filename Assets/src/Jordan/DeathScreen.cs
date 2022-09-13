using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // stop time
    // enable screen
    // quit or restart

    GameObject deathScreen;
    public static GameObject deathChild;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen = GameObject.Find("DeathScreen");
        deathChild = deathScreen.transform.GetChild(0).gameObject;
        deathChild.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // pops up the death screen and pauses the game
    public static void PlayerDied()
    {
        
        deathChild.SetActive(true);
        GameManager.HideOverlay();
        Time.timeScale = 0; 

        // to do:
        // need to stop player input
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
