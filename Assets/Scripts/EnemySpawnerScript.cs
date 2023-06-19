using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy_prefab;
    private float enemy_hp = 20f;
    private float enemy_speed = 10f;
    private string enemy_path = "Waypoints";
    private float enemy_spawn_rate = 1;

    private int counter = 999;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, enemy_spawn_rate);
    }
    private void SpawnEnemy()
    {
        counter--;
        if(counter <= 0) {CancelInvoke("SpawnEnemy");}
        Instantiate(enemy_prefab, transform.position, Quaternion.identity).GetComponent<EnemyMovementScript>().Initialize(enemy_speed, enemy_hp, enemy_path);
        
    }
}
