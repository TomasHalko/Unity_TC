using UnityEngine;
using UnityEngine.UI;

public class coilEnergy : MonoBehaviour
{
    private moneySystem mS;
    public Text gameScore;
    void Start()
    {
        mS = FindObjectOfType<moneySystem>();
    }
    // Update is called once per frame

    void Update()
    {
        gameScore.text = mS.gameScore.ToString("0");
    }
}
