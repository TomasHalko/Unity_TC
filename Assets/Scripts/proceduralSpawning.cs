using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralSpawning : MonoBehaviour
{
    public double dayNumber;
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

    // Unity Hooks
    private gameHandler gH;

    // Start is called before the first frame update
    void Start()
    {
        gH = FindObjectOfType<gameHandler>();
        StartCoroutine(waitSpawner());
        dayNumber = 6;
        difficultyIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {     
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

        if (gH.nextDay == true)
        {
            StartCoroutine(waitSpawner());
            gH.nextDay = false;
        }
    }
    
    IEnumerator waitSpawner()
    {   
        yield return new WaitForSeconds(startWait);

        while ((!stop) && (dayNumber == 1) && (difficultyIndex <= 1))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);
            randomGroundEnemy = Random.Range(0, groundEnemies.Length-1);

            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 1))
            {
                gH.numberOfEnemies += 1;
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 2) && (difficultyIndex <= 2))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 2))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 2))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 3) && (difficultyIndex <= 3))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 3))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 3))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 4) && (difficultyIndex <= 4))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);

            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 4))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 4))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 5) && (difficultyIndex <= 5))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);

            randomAirEnemy = Random.Range(0, airEnemies.Length);

            if ((randomAirEnemy == 0) && (difficultyIndex + 0.3 <= 5))
            {
                difficultyIndex += 0.3;
                Instantiate(airEnemies[randomAirEnemy], airSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }

        while ((!stop) && (dayNumber == 6) && (difficultyIndex <= 6))
        {
            Vector3 groundSpawnPosition = new Vector3(Random.Range(-groundSpawnValues.x - 13f, groundSpawnValues.x - 13f), Random.Range(-groundSpawnValues.y - 1.75f, groundSpawnValues.y - 1.75f), 1);
            Vector3 airSpawnPosition = new Vector3(Random.Range(-airSpawnValues.x - 13f, airSpawnValues.x - 13f), Random.Range(-airSpawnValues.y + 2.25f, airSpawnValues.y + 2.25f), 1);
            randomAirEnemy = Random.Range(0, airEnemies.Length - 1);
            randomGroundEnemy = Random.Range(0, groundEnemies.Length);
            

            if ((randomGroundEnemy == 0) && (difficultyIndex + 0.1 <= 6))
            {
                difficultyIndex += 0.1;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            else if ((randomGroundEnemy == 1) && (difficultyIndex + 0.3 <= 6))
            {
                difficultyIndex += 0.3;
                Instantiate(groundEnemies[randomGroundEnemy], groundSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            else if ((randomAirEnemy == 0) && (difficultyIndex + 0.3 <= 6))
            {
                difficultyIndex += 0.3;
                Instantiate(airEnemies[randomAirEnemy], airSpawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gH.numberOfEnemies += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
