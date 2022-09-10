/**
 * @file    Item.cs
 * @date    09-10-22
 * @class   CS 383
 * @project 2D-platformer
 * @brief   This file handles how items interact.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int points = 1; // how much to add to score
    public int damage = 0; // how much to detract from health
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when collided with, update score/health and disappear
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.UpdateScore(points);
        GameManager.UpdateHealth(damage);

        Destroy(gameObject);

    }
}
