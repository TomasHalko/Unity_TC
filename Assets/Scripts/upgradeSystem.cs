using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSystem : MonoBehaviour
{
    // Upgrade Values
    private float repairAmount = 100f;
    private float healthUpgradeAmount = 2000f;
    private float energyUpgradeAmount = 2000f;
    private float slowUpgradeAmount = 0.2f;
    public bool hasMiniCoil = false;

    // Unity Hooks
    private moneySystem mS;
    private coilStats C;
    private gameHandler gH;
    private Rigidbody2D rb;
    private proceduralSpawning pS;


    [SerializeField]
    private GameObject upgradeMenu;

    [SerializeField]
    private GameObject miniCoil;


    // Start is called before the first frame update
    void Start()
    {
        miniCoil.SetActive(!miniCoil.activeSelf);
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        mS = FindObjectOfType<moneySystem>();
        gH = FindObjectOfType<gameHandler>();
        rb = GetComponent<Rigidbody2D>();
        C = FindObjectOfType<coilStats>();
        pS = FindObjectOfType<proceduralSpawning>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void upgradeMenuActive()
    {
        Debug.Log("Upgrade");
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }

    public void upgradeCompleted()
    {
        upgradeMenu.SetActive(false);
        gH.enemiesKilled = 0;
    }

    public void repairCoil()
    {
        if (C.coilHealth <= C.coilHealthMax - repairAmount) 
        {
            C.coilHealth += repairAmount;
        }

        else
        {
            C.coilHealth += C.coilHealthMax - C.coilHealth;
        }
    }

    public void healthUpgrade()
    {
        C.coilHealthMax += healthUpgradeAmount;
        C.coilHealth += C.coilHealth * (percReplenishment(C.coilHealth, 0, C.coilHealthMax, 0, 100) / 100);
        healthUpgradeAmount += 2000f;
    }

    public void energyUpgrade()
    {
        C.coilEnergyMax += energyUpgradeAmount;
        C.coilEnergy += C.coilEnergy * (percReplenishment(C.coilEnergy, 0, C.coilEnergyMax, 0, 100) / 100);
        energyUpgradeAmount += 2000f;
    }
    
    public void purchaseMiniCoil()
    {
        hasMiniCoil = true;
        miniCoil.SetActive(!miniCoil.activeSelf);
    }

    public void slowUpgrade()
    {
        C.coilSlowRate -= slowUpgradeAmount;
        slowUpgradeAmount += 0.1f;
    }

    // Function that returns a value between 0 and 100
    // that is used to repair the Coil based on your health percentage
    public float percReplenishment(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return ((value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin) / 100 * healthUpgradeAmount;
    }
}

