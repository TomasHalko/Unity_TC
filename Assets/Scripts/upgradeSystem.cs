using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSystem : MonoBehaviour
{
    // Upgrade Values
        // Floats
    private float repairAmount = 100f;
    private float healthUpgradeAmount = 2000f;
    private float energyUpgradeAmount = 2000f;
    private float slowUpgradeAmount = 0.2f;
        // Integers
    private int repairCost = 150;
    private int healthUpgradeCost = 2000;
    private int energyUpgradeCost = 2000;
    private int slowUpgradeCost = 4000;
    private int miniCoilCost = 5000;
        // Booleans
    public bool hasMiniCoil = false;
        
    // Unity Hooks
    private moneySystem mS;
    private coilStats C;
    private gameHandler gH;
    private Rigidbody2D rb;
    private proceduralSpawning pS;

    // Game Objects
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

    // Function that opens the upgrade menu
    public void upgradeMenuActive()
    {
        pS.stop = true;
        Debug.Log("Upgrade");
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }

    // Next Day button 
    // Function that closes the upgrade menu
    public void upgradeCompleted()
    {
        upgradeMenu.SetActive(false);
        gH.enemiesKilled = 0;
        pS.stop = false;
        gH.nextDay = true;
    }

    // Upgrade 01
    // Function that calls for a repair
    public void repairCoil()
    {
        if ((C.coilHealth <= C.coilHealthMax - repairAmount) && (mS.gameCurrency >= repairCost))
        {
            C.coilHealth += repairAmount;
            mS.gameCurrency -= repairCost;
        }

        else if ((mS.gameCurrency >= repairCost) && (C.coilHealthMax != C.coilHealth))
        {
            C.coilHealth += C.coilHealthMax - C.coilHealth;
            mS.gameCurrency -= repairCost;
        }
        else if (C.coilHealthMax == C.coilHealth)
        {
            Debug.Log("HP Full!");
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    // Upgrade 02
    // Function that upgrades coils max health
    public void healthUpgrade()
    {
        if (mS.gameCurrency >= healthUpgradeCost)
        {
            C.coilHealthMax += healthUpgradeAmount;
            C.coilHealth += healthUpgradeAmount;
            mS.gameCurrency -= healthUpgradeCost;
            healthUpgradeCost += 3000;
            healthUpgradeAmount += 2000f;
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    // Upgrade 03
    // Function that upgrades coils max energy
    public void energyUpgrade()
    {
        if (mS.gameCurrency >= energyUpgradeCost)
        {
            C.coilEnergyMax += energyUpgradeAmount;
            C.coilEnergy += energyUpgradeAmount;
            mS.gameCurrency -= energyUpgradeCost;
            energyUpgradeCost += 3000;
            energyUpgradeAmount += 2000f;
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    // Upgrade 04
    // Function that enables mini coil
    public void purchaseMiniCoil()
    {
        if ((mS.gameCurrency >= miniCoilCost) && (hasMiniCoil == false))
        {
            mS.gameCurrency -= miniCoilCost;
            hasMiniCoil = true;
            miniCoil.SetActive(!miniCoil.activeSelf);
        }
        else if (hasMiniCoil == true)
        {
            Debug.Log("You already have Mini Coil!");
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    // Upgrade 05
    // Function that upgrades coil slow rate
    public void slowUpgrade()
    {
        if (mS.gameCurrency >= slowUpgradeCost)
        {
            mS.gameCurrency -= slowUpgradeCost;
            C.coilSlowRate -= slowUpgradeAmount;
            slowUpgradeAmount += 0.1f;
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
}

