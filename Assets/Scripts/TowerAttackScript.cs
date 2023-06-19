using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerAttackScript : MonoBehaviour
{
    public GameObject bullet_prefab;
    private float attack_speed = 0.1f;
    private float bullet_speed = 20f;
    private float bullet_life = 3f;
    private float attack_damage = 10f;
    
    [SerializeField]
    private List<GameObject> enemies = new();
    private GameObject target = null;

    private void Start()
    {
        StartCoroutine("AttackEnemy");
    }

    private void Update()
    {
        if (enemies.Count != 0)
        {
            // rotete the tower
            var direction = enemies[0].transform.position - transform.position;
            direction = direction.normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }

    public void Initialize(float attack_speed, float bullet_speed, float attack_range, float attack_damage, float bullet_life)
    {
        this.attack_speed = attack_speed;
        this.bullet_speed = bullet_speed;
        this.attack_damage = attack_damage;
        this.bullet_life = bullet_life;
        GetComponent<CircleCollider2D>().radius = attack_range;
    }

    private IEnumerator AttackEnemy()
    {
        while (true)
        {
            if (enemies.Count == 0) yield return null;
            else
            {
                target = enemies.First();
                // fire the bullet
                Instantiate(bullet_prefab, transform.position, Quaternion.identity).GetComponent<TowerBulletScript>().Initialize(bullet_speed, attack_damage, bullet_life, target);
                yield return new WaitForSeconds(attack_speed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            RemoveEnemy(other.gameObject);
        }    
    }

    public void RemoveEnemy(GameObject enemy)
    {   
        if(target == enemy) target = null;
        enemies.Remove(enemy);
    }
}
