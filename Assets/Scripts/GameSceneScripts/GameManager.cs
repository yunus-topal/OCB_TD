using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner");
        enemySpawner.GetComponent<EnemySpawnerScript>().InitializeEnemySpawner(50f, 10f, "Waypoints", 1f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
