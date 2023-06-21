using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy_prefab;
    public Sprite[] enemy_sprites;
    [SerializeField]
    private float[] enemy_hp = {50f, 100f, 150f, 200f};
    [SerializeField]
    private float[] enemy_speed = {10f, 20f, 30f, 40f};
    private string enemy_path = "Waypoints";
    private float enemy_spawn_rate = 1;

    private int counter = 999;

    public void InitializeEnemySpawner(int count)
    {
        counter = count;
        InvokeRepeating("SpawnEnemy", 0, enemy_spawn_rate);
    }
    private void SpawnEnemy()
    {
        counter--;
        if (counter <= 0)
        {
            CancelInvoke("SpawnEnemy");
            CallGameManager();
        }
        // generate random number between 0 and enemy_prefab size
        int index = Random.Range(0, enemy_sprites.Length);
        SpriteRenderer enemy_sprite = enemy_prefab.GetComponent<SpriteRenderer>();
        enemy_sprite.sprite = enemy_sprites[index];
        Instantiate(enemy_prefab, transform.position, Quaternion.identity).GetComponent<EnemyMovementScript>().InitializeEnemy(enemy_speed[index], enemy_hp[index], enemy_path);
        
    }

    private void CallGameManager()
    {
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().SetSpawnerFinished(true);
    }
}
