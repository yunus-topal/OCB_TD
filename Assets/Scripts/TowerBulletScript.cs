using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletScript : MonoBehaviour
{
    private float speed = 10f;
    private float damage = 10f;
    private Vector3 direction = Vector3.right;

    void Start()
    {
        
    }
    
    public void Initialize(float speed, float damage, Vector3 direction)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
