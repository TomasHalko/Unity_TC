using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierMovement : MonoBehaviour
{
    public float positionX;
    // Soldier Stats
    public float soldierSpeed = 30f;
    private float soldierSlowedSpeed;

    //Unity Hooks
    private soldierBehaviour sB;
    private Rigidbody2D rb;
    private coilStats C;

    // Start is called before the first frame update 
    void Start()
    {
        C = FindObjectOfType<coilStats>();
        rb = GetComponent<Rigidbody2D>();
        sB = FindObjectOfType<soldierBehaviour>();
        soldierSlowedSpeed = soldierSpeed * C.coilSlowRate;
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        positionX = rb.position.x;

        if ((Input.touchCount == 1) && (rb.position.x < sB.soldierAggroPos))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if ((GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) && (rb.position.x < 4.25))
            {
                soldierSpeed = soldierSlowedSpeed;
            }

        }
        else if (rb.position.x < sB.soldierAggroPos)
        {
            soldierSpeed = 30f;
        }

        else if (rb.position.x >= sB.soldierAggroPos)
        {
            StartCoroutine(stopSlide());
        }
        rb.velocity = new Vector2(soldierSpeed * Time.deltaTime, rb.velocity.y);
    }

    IEnumerator stopSlide()
    {
        yield return soldierSpeed = 0f;
    }
}

