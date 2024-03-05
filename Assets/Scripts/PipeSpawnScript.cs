using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 5;
    private bool isSpawning = false;
 
    void Start()
    {
        // spawnPipe();
    }
 
    void Update()
    {
       if (isSpawning) //Check the flag before spawning
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }
 
    }
 
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
 
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
     public void StartSpawning()
    {
        isSpawning = true;
    }
}