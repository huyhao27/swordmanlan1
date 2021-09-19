using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    public float speed;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (right)
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.6f, 0.6f);
        }
        else
        {
            transform.Translate(Time.deltaTime * -speed, 0, 0);
            transform.localScale = new Vector2(-0.6f, 0.6f);
        }
    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.CompareTag("dau"))
        {
            right = true;
        }
        else if
           (enemy.gameObject.CompareTag("cuoi"))
        {
            right = false;
        }
    }
}
