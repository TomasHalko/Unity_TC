using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSystem : MonoBehaviour
{
    private moneySystem mS;
    private coilStats C;
    private gameHandler gH;
    private Rigidbody2D rb;
    private proceduralSpawning pS;
    [SerializeField]
    private GameObject upgrades;


    // Start is called before the first frame update
    void Start()
    {
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
    }
}
