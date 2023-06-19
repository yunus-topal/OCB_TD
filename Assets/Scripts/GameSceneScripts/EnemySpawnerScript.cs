using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy_prefab;
    private float enemy_hp = 50f;
    private float enemy_speed = 10f;
    private string enemy_path = "Waypoints";
    private float enemy_spawn_rate = 1;

    private int counter = 999;

    public void InitializeEnemySpawner(float hp, float speed, string path, float spawn_rate, int count)
    {
        enemy_hp = hp;
        enemy_speed = speed;
        enemy_path = path;
        enemy_spawn_rate = spawn_rate;
        counter = count;
        InvokeRepeating("SpawnEnemy", 0, enemy_spawn_rate);
    }
    private void SpawnEnemy()
    {
        counter--;
        if(counter <= 0) {CancelInvoke("SpawnEnemy");}
        Instantiate(enemy_prefab, transform.position, Quaternion.identity).GetComponent<EnemyMovementScript>().InitializeEnemy(enemy_speed, enemy_hp, enemy_path);
        
    }
}
