using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class coilStats : MonoBehaviour
{ 
    // Coil Stats
    public float coilHealth = 1000f;
    public float coilHealthMax = 1000f;
    public float coilEnergy = 1000f;
    public float coilEnergyMax = 1000f;
    public float coilEnergyRechargePerSec = 1f;
    public float coilTapEnergyConsumption = 50f;
    public float coilHoldEnergyConsumption = 10f; 
    public float coilTapDamage = 0f;
    public float coilHoldDamage = 0f;
    public float coilSlowRate = 0.8f;

    // Unity Hooks 
    public Rigidbody2D rb;
    public Collider2D coll;
    public Vector2 startPos;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Get Unity Components
        rb = GetComponent<Rigidbody2D>();

        // Periodic function for recharging the coil
        FunctionPeriodic.Create(() =>
        {
            energyRecharge();
        }, 60 / coilEnergyRechargePerSec);
    }

    // Function that recharges the coil
    public void energyRecharge ()
    {
        // Most common scenario for recharging the coil
        if (((coilEnergy < coilEnergyMax) && (Input.touchCount < 1)) && (coilEnergyMax - coilEnergy > coilEnergyRechargePerSec))
        {
            coilEnergy += coilEnergyRechargePerSec;
        }

        // Prevents the function from overcharging the coil
        else if (Input.touchCount < 1)
        {
            coilEnergy += coilEnergyMax - coilEnergy;
        }
    }
}