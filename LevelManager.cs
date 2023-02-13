using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float maxHorizontal , maxVertical;
    Wyjazd cs;
    public GameObject AsteroidPrefab;
    private float spawnInterval = 3;
    private float spawnTimer = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxHorizontal = cs.worldWidth / 2 * 1.2f;
        maxVertical= cs.worldHeight / 2 * 1.2f;

    }
    void Spawn()
    {
        float randomX, randomZ;
        if(Mathf.Round(Random.Range(0,1))== 0 )
        {
            randomZ = Mathf.Round(Random.Range(0, 1)) * maxVertical;
            randomX = Random.Range(0, maxHorizontal);
        }
        else { 
            randomX = Mathf.Round(Random.Range(0, 1)) * maxHorizontal;
            randomZ = Random.Range(0, maxVertical);}
        Vector3 spawnpoint = new Vector3 (randomX,0, randomZ);
        Instantiate(AsteroidPrefab,spawnpoint,Quaternion.identity);
    }
}
