using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    private int waveNumber = 1;
    public TextMeshProUGUI waveNumberText;
    private bool waveInProgress = false;
    private bool spawnerFinished = false;

    public void SetSpawnerFinished(bool b)
    {
        spawnerFinished = b;
    }
    
    private GameObject enemySpawner;
    public Material lineMaterial;
    public GameObject optionsParent;

    private int currency = 100;

    public int GetCurrency()
    {
        return currency;
    }

    public void SetCurrency(int c)
    {
        this.currency = c;
        currencyText.text = currency.ToString();
    }

    public void IncreaseCurrency(int c)
    {
        currency += c;
    }
    
    public GameObject editMenuParent;
    public TextMeshProUGUI currencyText;

    private List<GameObject> lineObjects = new();
    private LineRenderer ld;
    
    private void Start()
    {
        // set up wave number
        UpdateWaveNumber(waveNumber);
        SetCurrency(currency);
        
        enemySpawner = GameObject.Find("EnemySpawner");
        lineObjects.Add(enemySpawner);
        GameObject waypoint = GameObject.Find("Waypoints");
        for (int i = 0; i < waypoint.transform.childCount; i++)
        {
            GameObject child = waypoint.transform.GetChild(i).gameObject;
            lineObjects.Add(child);
        }
        // set up ld
        ld = GetComponent<LineRenderer>();
        ld.enabled = false;
        PrepLine();
        
        // set up initial layout
        ShowOptionsLayout();
    }

    private void Update()
    {
        if(spawnerFinished && waveInProgress && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            waveInProgress = false;
            spawnerFinished = false;
            waveNumber++;
            UpdateWaveNumber(waveNumber);
            ShowOptionsLayout();
        }
    }

    
    private void UpdateWaveNumber(int x)
    {
        waveNumber = x;
        waveNumberText.text = "Wave " + waveNumber;
    }
    private void PrepLine()
    {
        ld.positionCount = lineObjects.Count;
        ld.startWidth = 0.1f;
        // Set the positions of the line renderer based on the points
        for (int i = 0; i < lineObjects.Count; i++)
        {
            ld.SetPosition(i, lineObjects[i].gameObject.transform.position);
        }
        ld.material = lineMaterial;
    }

    private void PrepareGame()
    {
        // hide buttons
        optionsParent.SetActive(false);

        // show currency and purchase buttons
        editMenuParent.SetActive(true);
        currencyText.text = currency.ToString();
        
        // enable line renderer
        ld.enabled = true;
    }

    public void ShowOptionsLayout()
    {
        // show buttons
        optionsParent.SetActive(true);
        editMenuParent.SetActive(false);
        ld.enabled = false;
    }
    
    public void StartGame()
    {
        Debug.Log("HIDE BUTTONS");
        // hide buttons
        optionsParent.SetActive(false);
        editMenuParent.SetActive(false);
        
        waveInProgress = true;
        enemySpawner.GetComponent<EnemySpawnerScript>().InitializeEnemySpawner(waveNumber * 10);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
