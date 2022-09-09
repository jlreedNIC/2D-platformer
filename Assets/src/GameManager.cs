/*
class to manage score, maybe health
also manages drbc death count
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score = 0;    // look up difference between public static and private in C#/unity
    
    public static int health = 3;   // should health be here? or with player script

    public int BCdeathCount = 0;    // set during menu
    private bool bcmode = false;

    // updating score on screen
    public GameObject game_overlay;
    Text scoreText;                 // text object for score
    Text healthText;                // text object for health
                                    // used for debugging purposes for now

    // Start is called before the first frame update
    void Start()
    {
        game_overlay = GameObject.Find("ScoreText"); // find the score text object
        scoreText = game_overlay.GetComponent<Text>(); // for updating the score string

        // reuse gameoverlay variable
        game_overlay = GameObject.Find("HealthText"); // only used in debugging!
        healthText = game_overlay.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        // tracks the number of times drbc has died
        if(bcmode)
        {
            if(health <= 0)
            {
                BCdeathCount++;
                health = 3; //max health
            }
        }
    }

    // updates the score by adding points
    public static void UpdateScore(int points)
    {
        score += points;
    }

    // updates the health variable to reflect taking damage
    public static void UpdateHealth(int value)
    {
        health -= value;
    }

    // add ongui for health and score display
}
