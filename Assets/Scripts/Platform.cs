using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformPrefab,breakable,spiked,Speed_Left,Speed_Right;
    List<GameObject> platformsList = new List<GameObject>();
    Vector2 spawnPoint;
    [SerializeField]
    float Min_X, Max_X;
    float MinTime,countTime = 0f;
    public string[] PlatformToBeSpawn;
    void Start()
    {
        spawnPoint = transform.position;
        MinTime = 2f;
        InititatePlatform();       
    }

    void Update()
    {
      SpawnPlatform();
    }

    void InititatePlatform()
    {
        for (int j = 0; j < 5; j++)
        {
            GameObject platformToSpawn = null;

            switch (j)
            {
                case 0:
                    platformToSpawn = platformPrefab; break;
                case 1:
                    platformToSpawn = breakable; break;
                case 2:
                    platformToSpawn = spiked; break;
                case 3:
                    platformToSpawn = Speed_Left; break;
                case 4:
                    platformToSpawn = Speed_Right; break;
            }
            
            for (int i = 0; i < 6; i++)
            {
                GameObject temp = Instantiate(platformToSpawn);
                temp.transform.SetParent(transform);
                temp.SetActive(false);
                platformsList.Add(temp);
            }
        }
    }

    void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        if (countTime >= MinTime)
        {
            countTime = 0f;
            MinTime = Random.Range(1.5f, 4f);
            int rand = Random.Range(0, 10);
            int randPlatform = Random.Range(1,5);
            for (int i = 0;i < platformsList.Count; i++)
            {
                if (rand > 5 && platformsList[i].tag == PlatformToBeSpawn[0] &&
                    !platformsList[i].activeInHierarchy)
                {
                    spawnPoint.x = Random.Range(Min_X, Max_X);
                    platformsList[i].transform.position = spawnPoint;
                    platformsList[i].SetActive(true);
                    platformsList[i].GetComponent<Rigidbody2D>().velocity = Vector2.up;
                    return;
                }
                else if(rand <= 5 && platformsList[i].tag == PlatformToBeSpawn[randPlatform] &&
                    !platformsList[i].activeInHierarchy)
                {
                    spawnPoint.x = Random.Range(Min_X, Max_X);
                    platformsList[i].transform.position = spawnPoint;
                    platformsList[i].SetActive(true);
                    platformsList[i].GetComponent<Rigidbody2D>().velocity = Vector2.up;
                    return;
                }               
            }
        }
    }
}
