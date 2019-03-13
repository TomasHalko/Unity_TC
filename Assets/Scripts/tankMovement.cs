using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankMovement : MonoBehaviour
{
    // Tank Stats
    public float tankSpeed = 35f;
    private float tankSlowedSpeed;

    // Unity Hooks
    private tankBehaviour tB;
    private Rigidbody2D rb;
    private coilStats C;

    // Start is called before the first frame update 
    void Start()
    {
        C = FindObjectOfType<coilStats>();
        rb = GetComponent<Rigidbody2D>();
        tB = FindObjectOfType<tankBehaviour>();
        tankSlowedSpeed = tankSpeed * C.coilSlowRate;
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        if ((Input.touchCount == 1) && (rb.position.x < tB.tankAggroPos))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                tankSpeed = tankSlowedSpeed;
            }
           
        }
        else if (rb.position.x < tB.tankAggroPos)
        {
            tankSpeed = 35f;
        }

        else if (rb.position.x >= tB.tankAggroPos)
        {
            StartCoroutine(stopSlide());
        }


        rb.velocity = new Vector2(tankSpeed * Time.deltaTime, rb.velocity.y);
    }

    IEnumerator stopSlide()
    {
        yield return tankSpeed = 0f;
    }
}
