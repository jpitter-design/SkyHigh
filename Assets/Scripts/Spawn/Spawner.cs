using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject BirdPrefab;

    public float SpawnRate = 1f; // How often does the Platform spawn
    public float minYSpacing = 2f; //So the platform don't spawn on eachother
    float LastYposition = 0;
    private Vector3 spawnPosition;


    public Transform playerTransform;
    public float DistanceFromPlayer = 2f; // The distance that the player is from the platform
   
    
    private float btimer; // a count to when the next time it will spawn a Bird
    private float timer;// a count to when the next time it will spawn a platform

    public int spawnLimit = 3;
    private List<GameObject> spawnCounts = new List<GameObject>();

    public GameManager start;
    public float NextBirdmin = 10f;
    public float NextBirdMax = 20f;
    public float NextBirdCurrent;
    public float delayTime = 1.0f;


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        Starts();

    }

    IEnumerator Starts()
    {

        yield return new WaitForSeconds(delayTime);
        start = GetComponent<GameManager>();


    }
    void Update()
    {
        
        //start.StartGame();
        if (playerTransform == null)
        {
            start.GameOver();
        }

        if (start.IsGameActive ==true)
        //if (IsGameActive == false) { return; }
        {
            if (spawnCounts.Count < spawnLimit)
            {
                timer += Time.deltaTime;
                btimer += Time.deltaTime;
            if (timer >= SpawnRate)
                {
                    timer = 0f;
                    SpawnPlatform();
                }
            }
            if (spawnCounts.Count == spawnLimit)
            {
                spawnCounts.RemoveAt(2);
            }
        if (btimer >= NextBirdCurrent)
        {
            BirdSpawn();
            btimer = 0f;
            NextBirdSpawn();

        }
        }

    }

        // This allow Spawn the platform 
        public void SpawnPlatform()
        {
        // Get a random x Positon 
            LastYposition += minYSpacing;
            //The X spawn range 
            float leftBound = Random.Range(-7.09f, playerTransform.position.x-1);
            float rightBound = Random.Range(playerTransform.position.x + 1, 10f);
            float RandomPosX = Random.Range(leftBound, rightBound);




        // Spawn to left or Right of player
  
            spawnPosition = new Vector3(RandomPosX, transform.position.y * 2 + LastYposition, transform.position.z);
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            spawnCounts.Add(newPlatform);
            
        }
    public void BirdSpawn()
    {
        float leftBound = -10f;
        //float rightBound = 10f;
        //float RandomPosX = Random.Range(leftBound, rightBound);



        // Spawn to left or Right of player

        Vector3 BspawnPos = new Vector3(leftBound, playerTransform.position.y, transform.position.z);
        GameObject newPlatform = Instantiate(BirdPrefab, BspawnPos, Quaternion.identity);
    }
    void NextBirdSpawn()
    {
        NextBirdCurrent = Random.Range(NextBirdmin, NextBirdMax);
    }
     
}