using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletScript : MonoBehaviour
{
    private float speed = 10f;
    private float damage = 10f;
    private Vector3 direction = Vector3.right;
    private float life_time = 3f;
    
    public void Initialize(float speed, float damage, float time, Vector3 direction)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
        this.life_time = time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyMovementScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
