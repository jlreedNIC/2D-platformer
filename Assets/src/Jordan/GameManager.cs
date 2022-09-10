/**
 * @file    GameManager.cs
 * @date    09-10-22
 * @class   CS 383
 * @project 2D-platformer
 * @brief   This file manages the score, health, and the general in-game overlay.
 *          It also manages the drbc death count.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score = 0;    // look up difference between public static and private in C#/unity
    
    public static int health = 3;
    public static int maxHealth = 3;

    public int BCdeathCount = 0;
    private bool bcmode = false;    // set during start menu

    // updating score on screen
    public GameObject game_overlay;
    Text scoreText;                 // text object for score
    Text healthText;                // text object for health

    // Start is called before the first frame update
    void Start()
    {
        // get scoreText object and get text component
        game_overlay = GameObject.Find("ScoreText");
        scoreText = game_overlay.GetComponent<Text>();

        // get healthText object and get text component
        game_overlay = GameObject.Find("HealthText");
        healthText = game_overlay.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // update score and health on screen
        scoreText.text = "Score: " + score;
        healthText.text = "x " + health;

        // tracks the number of times drbc has died
        if(bcmode)
        {
            if(health <= 0)
            {
                BCdeathCount++;
                health = maxHealth;
            }
        }

        // need to add a you died screen
    }

    // updates the score by adding points
    public static void UpdateScore(int points)
    {
        score += points;
    }

    // updates the health variable to reflect taking damage
    public static void UpdateHealth(int value)
    {
        // health is capped at 0 and maxHealth
        if(value < 0 && health < maxHealth)
        {
            health -= value;
        }
        else if(value > 0 && health > 0)
        {
            health -= value;
        }
    }
}
