using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class tankBehaviour : MonoBehaviour
{
    //tankStats
    public float tankHealth = 10000f;
    public float tankDamage = 500f;
    public float tankFireRate = 30f;
    public float tankAggroPos = 3f;

    //Unity Hooks
    private GameObject Import;
    private moneySystem mS;
    private coilStats C;
    private gameHandler gH;
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        mS = FindObjectOfType<moneySystem>();
        gH = FindObjectOfType<gameHandler>();
        rb = GetComponent<Rigidbody2D>();
        Import = FindObjectOfType<GameObject>();
        C = FindObjectOfType<coilStats>();

        FunctionPeriodic.Create(() =>
            {
                if (rb != null)
                {
                    if (rb.position.x > tankAggroPos)
                    {
                        tankAggro();
                    }
                }
            }, 60f / tankFireRate);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            //If player clicks on the enemy
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on TouchPhase
                switch (touch.phase)
                {
                    //When a touch has first been detected, change the Debug.Log(""); and record the starting position
                    case TouchPhase.Began:
                        // Record initial touch position.
                        startPos = touch.position;
                        coilTapDamage();
                        break;

                    case TouchPhase.Ended:
                        // Record initial touch position.
                        break;
                        
                    //Determine if the touch is a moving touch
                    case TouchPhase.Moved:
                        // Determine direction by comparing the current touch position with the initial one
                        direction = touch.position - startPos;
                        coilHoldDamage();
                        break;

                    case TouchPhase.Stationary:
                        // Report that the touch is stationary
                        coilHoldDamage();
                        break;
                }
            }
            //If player misses the enemy
            else
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on TouchPhase
                switch (touch.phase)
                {
                    //When a touch has first been detected, change the Debug.Log(""); and record the starting position
                    case TouchPhase.Began:
                        // Record initial touch position.
                        startPos = touch.position;
                        coilTapMiss();
                        break;

                    //Determine if the touch is a moving touch
                    case TouchPhase.Moved:
                        // Determine direction by comparing the current touch position with the initial one
                        direction = touch.position - startPos;
                        coilHoldMiss();
                        break;

                    case TouchPhase.Stationary:
                        // Report that the touch is stationary
                        coilHoldMiss();
                        break;
                }
            }
        }
    }

    private void coilTapDamage()
    {
        if (C.coilEnergy >= C.coilTapEnergyConsumption)
        {
            tankHealth -= C.coilTapDamage;
            C.coilEnergy -= C.coilTapEnergyConsumption;
            Debug.Log("Tank took: " + C.coilTapDamage);
        }

        if (tankHealth <= 0)
        {
            gH.numberOfEnemies -= 1;
            mS.gameCurrency += 1150;
            mS.gameScore += 2150;
            Destroy(gameObject);
        }

    }

    private void coilHoldDamage()
    {
        if (C.coilEnergy >= C.coilHoldEnergyConsumption)
        {
            tankHealth -= C.coilHoldDamage;
            C.coilEnergy -= C.coilHoldEnergyConsumption;
            Debug.Log("Tank took: " + C.coilHoldDamage);
        }

        if (tankHealth <= 0)
        {
            gH.numberOfEnemies -= 1;
            mS.gameCurrency += 1150;
            mS.gameScore += 2150;
            Destroy(gameObject);
        }

    }

    private void coilTapMiss()
    {
        if (C.coilEnergy >= C.coilTapEnergyConsumption)
        {
            C.coilEnergy -= C.coilTapEnergyConsumption;
            Debug.Log("You missed");
        }

    }

    private void coilHoldMiss()
    {
        if (C.coilEnergy >= C.coilHoldEnergyConsumption)
        {
            C.coilEnergy -= C.coilHoldEnergyConsumption;
            Debug.Log("You missed");
        }
    }

    private void tankAggro()
    {
        if (C.coilHealth > 0)
        {
            if (C.coilHealth < tankDamage)
            {
                C.coilHealth -= C.coilHealth;

            }
            else
            {
                C.coilHealth -= tankDamage;
            }
        }

    }
}