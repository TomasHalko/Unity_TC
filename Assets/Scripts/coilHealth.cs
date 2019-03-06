using UnityEngine.UI;
using UnityEngine;

public class coilHealth : MonoBehaviour
{
    private moneySystem mS;
    public Text gameCurrency;
    void Start()
    {
        mS = FindObjectOfType<moneySystem>();
    }
    // Update is called once per frame

    void Update()
    {
        gameCurrency.text = mS.gameCurrency.ToString("0");
    }
}
