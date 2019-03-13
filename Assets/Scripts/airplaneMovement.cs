using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneMovement : MonoBehaviour
{   
    // Airplane Stats
    public float airplaneSpeed = 65f;
    private float airplaneSlowedSpeed;

    // Unity Hooks
    private airplaneBehaviour aB;
    private Rigidbody2D rb;
    private coilStats C;

    // Start is called before the first frame update 
    void Start()
    {
        C = FindObjectOfType<coilStats>();
        rb = GetComponent<Rigidbody2D>();
        aB = FindObjectOfType<airplaneBehaviour>();
        airplaneSlowedSpeed = airplaneSpeed * C.coilSlowRate;
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                airplaneSpeed = airplaneSlowedSpeed;
            }

        }

        else
        {
            airplaneSpeed = 65f;
        }

        rb.velocity = new Vector2(airplaneSpeed * Time.deltaTime, rb.velocity.y);
    }

    IEnumerator stopSlide()
    {
        yield return airplaneSpeed = 0f;
    }
}
