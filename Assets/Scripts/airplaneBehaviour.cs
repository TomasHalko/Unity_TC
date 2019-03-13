using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class airplaneBehaviour : MonoBehaviour
{
    // Airplane Stats
    public float airplaneHealth = 1000f;
    public float airplaneDamage = 150f;
    public float airplaneFireRate = 200f;
    public float airplaneAggroPosStart = 0f;
    public float airplaneAggroPosEnd = 5f;

    // Unity Hooks
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
                if ((rb.position.x > airplaneAggroPosStart) && (rb.position.x < airplaneAggroPosEnd))
                {
                    airplaneAggro();
                }

                else if (rb.position.x > 12)
                {
                    destroyAirplane();
                }
            }
        }, 60 / airplaneFireRate);

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
            airplaneHealth -= C.coilTapDamage;
            C.coilEnergy -= C.coilTapEnergyConsumption;
            Debug.Log("Airplane took: " + C.coilTapDamage);
        }

        if (airplaneHealth <= 0)
        {
            gH.numberOfEnemies -= 1;
            mS.gameCurrency += 1250;
            mS.gameScore += 2850;
            Destroy(gameObject);
        }

    }

    private void coilHoldDamage()
    {
        if (C.coilEnergy >= C.coilHoldEnergyConsumption)
        {
            airplaneHealth -= C.coilHoldDamage;
            C.coilEnergy -= C.coilHoldEnergyConsumption;
            Debug.Log("Airplane took: " + C.coilHoldDamage);
        }

        if (airplaneHealth <= 0)
        {
            gH.numberOfEnemies -= 1;
            mS.gameCurrency += 1250;
            mS.gameScore += 2850;
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

    private void airplaneAggro()
    {
        if (C.coilHealth > 0)
        {
            if (C.coilHealth < airplaneDamage)
            {
                C.coilHealth -= C.coilHealth;

            }
            else
            {
                C.coilHealth -= airplaneDamage;
            }
        }

    }
    private void stopAirplaneAggro()
    {
        airplaneDamage = 0f;
    }   

    private void destroyAirplane()
    {
        Destroy(gameObject);
    }
}
