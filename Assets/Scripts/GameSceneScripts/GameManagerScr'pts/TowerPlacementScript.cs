using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacementScript : MonoBehaviour
{
    public GameObject[] towers;
    private float[][] towerStats =
    {
        new float[] {0.25f,0.5f,30f}, 
        new float[] {0.2f,0.5f,20f}
    };
    
    public GameObject towerParent;

    private int[] towerPrices = { 50, 40 };
    
    private int placingTower = -1;

    private void Start()
    {
        towerParent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void PlaceTower1()
    {
        if(GetComponent<GameManager>().GetCurrency() < towerPrices[0])
            return;
        placingTower = 0;
        towerParent.SetActive(false);
        StartCoroutine(TowerPlacement());
    }
    
    public void PlaceTower2()
    {
        if(GetComponent<GameManager>().GetCurrency() < towerPrices[1])
            return;
        placingTower = 1;
        towerParent.SetActive(false);
        StartCoroutine(TowerPlacement());
    }

    private IEnumerator TowerPlacement()
    {
        GameObject tower = Instantiate(towers[placingTower], transform.position, Quaternion.identity);
        // get mouse position on every frame and move tower to that position
        while (placingTower >= 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            tower.transform.position = objectPos;
            
            if(Input.GetMouseButtonDown(0))
            {
                // reduce currency, place tower, reshow purchase buttons.
                GetComponent<GameManager>().SetCurrency(GetComponent<GameManager>().GetCurrency() - towerPrices[placingTower]);
                towerParent.SetActive(true);
                tower.GetComponent<TowerAttackScript>().InitializeTower(towerStats[placingTower][0], 40f, towerStats[placingTower][1], towerStats[placingTower][2], 3f);
                placingTower = -1;
            } else if (Input.GetMouseButtonDown(1))
            {
                Destroy(tower);
                placingTower = -1;
                towerParent.SetActive(true);
            }
            
            yield return null;
        }
    }
}
