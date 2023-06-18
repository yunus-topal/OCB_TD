using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackScript : MonoBehaviour
{
    public GameObject bullet_prefab;
    public float attack_speed = 1f;
    public float bullet_speed = 10f;
    public float attack_range = 10f;
    public float attack_damage = 10f;
    private float attack_timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack_timer <= 0f)
        {
            GameObject bullet = Instantiate(bullet_prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<TowerBulletScript>().Initialize(bullet_speed, attack_damage, Vector3.right);
            attack_timer = attack_speed;
        }
        attack_timer -= Time.deltaTime;
    }

}
