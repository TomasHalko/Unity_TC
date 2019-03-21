using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSystem : MonoBehaviour
{
    // Upgrade Values
    private float repairAmount;
    private float healthUpgradeAmount;

    // Unity Hooks
    private moneySystem mS;
    private coilStats C;
    private gameHandler gH;
    private Rigidbody2D rb;
    private proceduralSpawning pS;


    [SerializeField]
    private GameObject upgradeMenu;


    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        mS = FindObjectOfType<moneySystem>();
        gH = FindObjectOfType<gameHandler>();
        rb = GetComponent<Rigidbody2D>();
        C = FindObjectOfType<coilStats>();
        pS = FindObjectOfType<proceduralSpawning>();

        repairAmount = 100f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void upgradeMenuActive()
    {
        Debug.Log("Upgrade");
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        Time.timeScale = 1;
    }

    public void upgradeCompleted()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
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

    public void healthUpgrade1()
    {
        C.coilHealthMax += healthUpgradeAmount;
        C.coilHealth += healthReplenish(C.coilHealth, 0, C.coilHealthMax, 0, 100);
    }

    // Function that returns a value between 0 and 100
    // that is used to repair the Coil based on your health percentage
    public float healthReplenish(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return ((value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin) / 100 * healthUpgradeAmount;
    }
}
