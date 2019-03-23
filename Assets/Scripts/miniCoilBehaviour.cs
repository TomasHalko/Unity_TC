using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class miniCoilBehaviour : MonoBehaviour
{
    // Mini Coil Stats
    private float miniCoilDamage = 100f;
    private float miniCoilFireRate = 60f;

    // Unity Hooks
    private upgradeSystem uS;

    // Start is called before the first frame update
    void Start()
    {
        uS = FindObjectOfType<upgradeSystem>();
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
    }

    public void miniCoilAggro()
    {
        Debug.Log("Shoot!");
    }
}
