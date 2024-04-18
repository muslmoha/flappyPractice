using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float spawnCD;
    [SerializeField] float minVariance;
    [SerializeField] float maxVariance;

    private float timeOfLastSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfLastSpawn + spawnCD)
        {
            Vector3 spawnPos = transform.position;

            spawnPos.y = UnityEngine.Random.Range(minVariance, maxVariance);
            Instantiate(pipePrefab, spawnPos, Quaternion.identity);
            timeOfLastSpawn = Time.time;
        }
    }
}
