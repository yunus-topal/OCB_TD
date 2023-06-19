using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletScript : MonoBehaviour
{
    private float speed = 10f;
    private float damage = 10f;
    private GameObject target = null;
    private float life_time = 3f;
    private Vector3 direction;
    
    public void InitializeBullet(float speed, float damage, float time, GameObject target)
    {
        this.speed = speed;
        this.damage = damage;
        this.target = target;
        this.life_time = time;
        direction = this.target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        life_time -= Time.deltaTime;
        transform.position += direction * (speed * Time.deltaTime);

        if (life_time <= 0) Destroy(gameObject);
        if (target != null) direction = target.transform.position - transform.position;
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
