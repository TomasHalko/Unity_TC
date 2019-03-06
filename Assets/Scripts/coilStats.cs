using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class coilStats : MonoBehaviour
{ 
    //Coil Stats
    public float coilHealth = 1000f;
    public float coilEnergy = 1000f;
    public float coilEnergyMax = 1000f;
    public float coilEnergyRechargePerSec = 1f;
    public float coilTapEnergyConsumption = 50f;
    public float coilHoldEnergyConsumption = 10f; 
    public float coilTapDamage = 0f;
    public float coilHoldDamage = 0f;
    public float coilSlowRate = 0.6f;

    //Unity hooks 
    [SerializeField] public actualHealthBar healthBar;
    [SerializeField] public actualEnergyBar energyBar;
    public Rigidbody2D rb;
    public Collider2D coll;
    public Vector2 startPos;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        FunctionPeriodic.Create(() =>
        {
            healthBar.SetSize(0f + coilHealth / 5000f);
            energyBar.SetSize(0f + (coilEnergy / 5000f));

        }, 0.005f);

        FunctionPeriodic.Create(() =>
        {
            energyRecharge();
        }, 60 / coilEnergyRechargePerSec);
    }

    public void energyRecharge ()
    {
        if (((coilEnergy < coilEnergyMax) && (Input.touchCount < 1)) && (coilEnergyMax - coilEnergy > coilEnergyRechargePerSec))
        {
            coilEnergy += coilEnergyRechargePerSec;
        }
        else if (Input.touchCount < 1)
        {
            coilEnergy += coilEnergyMax - coilEnergy;
        }
    }
}