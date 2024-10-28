using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingPrefabs;
    [SerializeField] private Transform[] SpawnFloorOne;
    [SerializeField] private Transform[] SpawnFloorTwo;
    [SerializeField] private GameObject[] Stairs;

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();
        }
    }


    private void Generate()
    {
        int floor = Random.Range(0, buildingPrefabs.Length);
        for (int i = 0; i < SpawnFloorOne.Length; i++)
        {
            if (SpawnFloorOne[i].childCount > 0)
            {
                Destroy(SpawnFloorOne[i].GetChild(0).gameObject);
            }
   
            GameObject building = Instantiate(buildingPrefabs[floor], SpawnFloorOne[i].position, buildingPrefabs[floor].transform.rotation);
        }

        int ranText = Random.Range(0, buildingPrefabs.Length); 
        int ranNum = 0;
        for (int i = 0; i < 100; i++)
        {
            for (int x = 0; x < SpawnFloorTwo.Length; x++){
            ranNum = Random.Range(0, SpawnFloorTwo.Length);
        }
            
            if (SpawnFloorTwo[ranNum].childCount > 0)
            {
                Destroy(SpawnFloorTwo[ranNum].GetChild(0).gameObject);
            }

            GameObject building = Instantiate(buildingPrefabs[ranText], SpawnFloorTwo[ranNum].position, buildingPrefabs[ranText].transform.rotation);   
        }
    

        int ranStair = Random.Range(0, Stairs.Length); 
        int ranNum2 = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int x = 0; x < SpawnFloorTwo.Length; x++){
            ranNum2 = Random.Range(0, SpawnFloorTwo.Length);
        }
            
            if (SpawnFloorTwo[ranNum2].childCount > 0)
            {
                Destroy(SpawnFloorTwo[ranNum2].GetChild(0).gameObject);
            }

            GameObject building = Instantiate(Stairs[ranStair], SpawnFloorTwo[ranNum2].position, Stairs[ranStair].transform.rotation);   
        }


    }
}


