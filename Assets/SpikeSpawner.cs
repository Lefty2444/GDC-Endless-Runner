using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSpike", 1, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSpike()
    {
        if (Random.Range(0, 20) == 1)
        {
            Instantiate(spike, transform.position, transform.rotation);
            Time.timeScale += .02f;
        }
    }
}
