using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject enemySpawner;
    
    public Material lineMaterial;
    public Button startButton;
    public Button exitButton;
    public Button prepareButton;

    private List<GameObject> lineObjects = new();
    private LineRenderer ld;
    private void Start()
    {
        ld = GetComponent<LineRenderer>();
        ld.enabled = false;
        enemySpawner = GameObject.Find("EnemySpawner");

        lineObjects.Add(enemySpawner);
        GameObject waypoint = GameObject.Find("Waypoints");
        for (int i = 0; i < waypoint.transform.childCount; i++)
        {
            GameObject child = waypoint.transform.GetChild(i).gameObject;
            lineObjects.Add(child);
        }
    }
    
    public void StartGame()
    {
        enemySpawner.GetComponent<EnemySpawnerScript>().InitializeEnemySpawner(50f, 10f, "Waypoints", 1f, 10);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void PrepareGame()
    {
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        prepareButton.gameObject.SetActive(false);
        
        // enable line renderer
        ld.enabled = true;
        ld.positionCount = lineObjects.Count;
        ld.startWidth = 0.1f;
        // Set the positions of the line renderer based on the points
        for (int i = 0; i < lineObjects.Count; i++)
        {
            ld.SetPosition(i, lineObjects[i].gameObject.transform.position);
        }
        ld.material = lineMaterial;
    }
}
