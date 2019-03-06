using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyMovement : MonoBehaviour
{
    public float horizVel = 1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizVel * Time.deltaTime, rb.velocity.y);
        
        if (rb.position.x > 4)
        {
            StartCoroutine(stopSlide());
        }
    }

    IEnumerator stopSlide()
    {
        yield return horizVel = 0f;
    }
}