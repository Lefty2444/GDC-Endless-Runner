using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public float rate;    
    public float cutoff;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnStage", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-rate * Time.deltaTime, 0, 0);
        if (transform.position.x < -cutoff)
        {
            transform.Translate(cutoff * 2, 0, 0);
        }
    }
    void SpawnStage()
    {

    }
}
