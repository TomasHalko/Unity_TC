using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class miniCoilBehaviour : MonoBehaviour
{
    // Mini Coil Stats
    private float miniCoilDamage = 800f;
    private float miniCoilFireRate = 60f;
    private float miniCoilRange = 89.8f;

    // Unity Hooks
    private upgradeSystem uS;
    private airplaneBehaviour aB;
    private soldierBehaviour sB;
    private tankBehaviour tB;
    public string enemy_name;
    public Transform targetLocked;
    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {

        uS = FindObjectOfType<upgradeSystem>();


        InvokeRepeating("updateTarget", 0f, 0.5f);

            // Periodic function for 
            FunctionPeriodic.Create(() =>
            {
                if ((uS.hasMiniCoil == true) && (targetLocked != null))
                {
                    miniCoilAggro();
                }     
            }, 60f / miniCoilFireRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void updateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        enemy_name = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= miniCoilRange)
        {
            enemy_name = nearestEnemy.name;
            targetLocked = nearestEnemy.transform;
        }
        else
        {
            targetLocked = null;
        }
    }

    public void miniCoilAggro()
    {
        if ((enemy_name == "Soldier(Clone)") && (enemy_name != null))
        {
            Debug.Log("Soldier locked");
            soldierBehaviour sB = targetLocked.GetComponentInChildren<soldierBehaviour>();
            sB.soldierHealth -= miniCoilDamage;
        }
        else if ((enemy_name == "Tank(Clone)") && (enemy_name != null))
        {
            Debug.Log("Tank locked");
            tankBehaviour tB = targetLocked.GetComponentInChildren<tankBehaviour>();
            tB.tankHealth -= miniCoilDamage;
        }
        else if ((enemy_name == "Airplane(Clone)") && (enemy_name != null))
        {
            Debug.Log("Airplane locked");
            airplaneBehaviour aB = targetLocked.GetComponentInChildren<airplaneBehaviour>();
            aB.airplaneHealth -= miniCoilDamage;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, miniCoilRange/10);
    }

    void GetTransformScripts()
    {
        soldierBehaviour sB = targetLocked.GetComponentInChildren<soldierBehaviour>();
        tankBehaviour tB = targetLocked.GetComponentInChildren<tankBehaviour>();
        airplaneBehaviour aB = targetLocked.GetComponentInChildren<airplaneBehaviour>();   
    }
}

