using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-rate * Time.deltaTime, 0, 0);
        //while playing the game, i ran into an issue where spikes would spawn too close, and jumping over one would cause you to land right on the next
        //i see two ways to fix this issue: 
        //make the player jump higher or shorter depending on how long they hold the space bar
        //make the spikes more spaced apart
        //i think the space bar one is the best
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
