using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int points = 1; // how much to add to score
    public int damage = 0; // how much to detract from health
    // think about separate classes for above
    // look into instances

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
        // call update score instead?
        GameManager.UpdateScore(points);
        // health -= damage;
        // call update health

        Destroy(gameObject);

    }
}
