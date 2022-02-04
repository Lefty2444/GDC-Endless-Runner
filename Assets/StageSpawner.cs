using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnStage", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-rate * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            transform.Translate(20, 0, 0);
        }
    }
    void SpawnStage()
    {

    }
}
