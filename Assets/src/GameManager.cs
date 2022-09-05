/*
class to manage score, maybe health
also manages drbc death count
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // look up difference between public static and private in C#/unity
    public static int score = 0;
    
    // should health be here?
    public static int health = 3;

    public int BCdeathCount = 0;    // set during menu
    private bool bcmode = false;

    // updating score on screen
    public GameObject game_overlay; // find way to update text
    // might need to use textmesh

    // Start is called before the first frame update
    void Start()
    {
        game_overlay = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if(bcmode)
        {
            if(health <= 0)
            {
                BCdeathCount++;
                health = 3; //max health
            }
        }
    }

    public static void UpdateScore(int points)
    {
        score += points;
    }

    // add ongui for health and score display
}
