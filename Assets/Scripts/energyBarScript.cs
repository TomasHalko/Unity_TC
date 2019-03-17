using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBarScript : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private Image energyValue;

    // Unity Hooks
    private coilStats C;
    private upgradeSystem uS;
    private proceduralSpawning pS;

    // Start is called before the first frame update
    void Start()
    {
        C = FindObjectOfType<coilStats>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        energyValue.fillAmount = Map(C.coilEnergy, 0, C.coilEnergyMax, 0, 1);
    }

    // Function that returns a value between 0 and 1 that is used to fill the Health Bar
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // (80 - 0) * (1 - 0) / (100 - 0) + 0
        // 80 * 1 / 100 = 0.8
        // or
        // 78 * 1 / 230 = 0.339
    }
}

