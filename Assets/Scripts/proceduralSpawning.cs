using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralSpawning : MonoBehaviour
{
    public int dayNumber;
    public int numberOfSpawns;
    public double difficultyIndex;
    public GameObject[] groundEnemies;
    public Vector3 groundSpawnValues;
    public GameObject[] airEnemies;
    public Vector3 airSpawnValues;
    private float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    private int randomGroundEnemy;
    private int randomAirEnemy;
    private gameHandler gH;

    // Start is called before the first frame update
    void Start()
    {
        gH = FindObjectOfType<gameHandler>();
        StartCoroutine(waitSpawner());
        dayNumber = 1;
        difficultyIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    
    IEnumerator waitSpawner()
    {   
        yield return new WaitForSeconds(startWait);

        while ((!stop) && (dayNumber == 1) && (difficultyIndex <= 1))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y, airSpawnValues.y), 1);
            randomGroundEnemy = Random.Range(0, groundEnemies.Length-1);

            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 1))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 2) && (difficultyIndex <= 2))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y, airSpawnValues.y), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 2))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 2))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }           
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 3) && (difficultyIndex <= 3))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y, airSpawnValues.y), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 3))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 3))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 4) && (difficultyIndex <= 4))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y, airSpawnValues.y), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 4))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 4))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 5) && (difficultyIndex <= 5))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y + 4.75f, airSpawnValues.y + 4.75f), 1);

            randomAirEnemy = Random.Range(0, airEnemies.Length);

            if ((randomAirEnemy == 0) && (difficultyIndex + 0.3 <= 5))
            {
                difficultyIndex += 0.3;
                Instantiate(airEnemies[randomAirEnemy], airSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 6) && (difficultyIndex <= 6))
        {
            gH.nextDay = true;
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x, groundSpawnValues.x), Random.Range(-groundSpawnValues.y + 0.3f, groundSpawnValues.y + 0.3f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x, airSpawnValues.x), Random.Range(-airSpawnValues.y + 4.75f, airSpawnValues.y + 4.75f), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            randomAirEnemy = Random.Range(0, airEnemies.Length);

            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 6))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 6))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            if ((randomAirEnemy == 0) && (difficultyIndex + 0.3 <= 6))
            {
                difficultyIndex += 0.3;
                Instantiate(airEnemies[randomAirEnemy], airSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
                gH.wasSpawned = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
