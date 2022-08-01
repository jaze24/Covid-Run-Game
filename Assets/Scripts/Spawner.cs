using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float decreaseTime;
    public float minTime = 0.65f;


 
    private void Update()
    {
    
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);

            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            
            if (startTimeBtwSpawns > minTime) {
                startTimeBtwSpawns -= decreaseTime;
            }
        }
        
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}


 /* This is instantiating a random obstacle pattern from the obstaclePatterns array at the
    position of the spawner. It is also setting the time between spawns to the start time
            between
            spawns. */
            
            /* This is checking if the start time between spawns is greater than the minimum time. If
            it is, it is decreasing the start time between spawns by the decrease time. */
            
            /* This is decreasing the time between spawns by the time between frames. */