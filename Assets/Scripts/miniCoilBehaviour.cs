using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class miniCoilBehaviour : MonoBehaviour
{
    public Transform target;
    public Transform soldier;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float damage = 50f;

    // Mini Coil Stats
    private float miniCoilDamage = 100f;
    private float miniCoilFireRate = 60f;

    // Unity Hooks
    private upgradeSystem uS;
    private airplaneBehaviour aB;
    private soldierBehaviour sB;

    // Start is called before the first frame update
    void Start()
    {
        uS = FindObjectOfType<upgradeSystem>();


        InvokeRepeating("updateTarget", 0f, 0.5f);

            // Periodic function for 
            FunctionPeriodic.Create(() =>
            {
                if ((uS.hasMiniCoil == true) && (target != null))
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

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void miniCoilAggro()
    {
        GetTransformScripts();
        Debug.Log("Shoot!");
        if (target = soldier)
        {
            sB.soldierHealth -= damage;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range/10);
    }

    void GetTransformScripts()
    {
        sB = target.GetComponent<soldierBehaviour>();
        aB = target.GetComponent<airplaneBehaviour>();
    }
}

