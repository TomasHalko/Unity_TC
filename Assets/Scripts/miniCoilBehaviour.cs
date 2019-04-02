using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class miniCoilBehaviour : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public int damage = 50;

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
        aB = FindObjectOfType<airplaneBehaviour>();
        sB = FindObjectOfType<soldierBehaviour>();

        InvokeRepeating("updateTarget", 0f, 0.5f);

        if (uS.hasMiniCoil == true)
        {
            // Periodic function for 
            FunctionPeriodic.Create(() =>
            {
                miniCoilAggro();
            }, 60f / miniCoilFireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            
        }
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
        Debug.Log("Shoot!");
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range/10);
    }

    // TESTING
      /* void Damage(Transform target)
    {
        Enemy e = target.GetComponent<soldierBehaviour>();

        if (e != null)
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float amount)
    {
        soldierHealth -= amount;

        if (soldierHealth <= 0)
        {
            Destroy(gameObject);
        }
    } */
}

