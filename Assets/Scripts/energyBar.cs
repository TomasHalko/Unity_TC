using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public GameObject Import;
    public coilStats C;
    public Text coilEnergyText;
    void Start()
    {
        C = Import.GetComponent<coilStats>();
    }
    // Update is called once per frame

    void Update()
    {
        coilEnergyText.text = C.coilHealth.ToString("0");
    }
}

