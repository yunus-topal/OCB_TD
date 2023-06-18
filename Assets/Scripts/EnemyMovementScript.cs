using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 10f;
    private float hp = 100f;
    private string waypoint_name = "Waypoints";
    
    private GameObject waypoint;
    private List<GameObject> points = new List<GameObject>(); 
    private int current_point = 0;
    private bool is_moving = false;
    private void Start()
    {
        waypoint = GameObject.Find(waypoint_name);
        for (int i = 0; i < waypoint.transform.childCount; i++)
        {
            GameObject child = waypoint.transform.GetChild(i).gameObject;
            points.Add(child);
            Debug.Log(child.name);
        }
    }

    public void Initialize(float speed, float hp, string waypoint_name="Waypoints")
    {
        this.speed = speed;
        this.hp = hp;
        this.waypoint_name = waypoint_name;
    }
    
    private void Update()
    {
        if (!is_moving && current_point < points.Count)
        {
            StartCoroutine(Run(current_point));
        }
    }

    private IEnumerator Run(int index)
    {
        var target_pos = points[index].transform.position;
        var direction = target_pos - transform.position;
        direction = direction.normalized;
        
        is_moving = true;
        var runtime = Vector3.Distance(transform.position, target_pos) / speed;
        for (var i = 0f; i < runtime; i+= Time.deltaTime)
        {
            transform.position += direction * (speed * Time.deltaTime);
            yield return null;
        }
        current_point++;
        is_moving = false;
    }
}
