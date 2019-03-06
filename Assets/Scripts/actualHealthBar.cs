using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualHealthBar : MonoBehaviour
{
    public Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize (float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
