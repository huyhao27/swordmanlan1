using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
   public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D orther)
    {
        if (orther.gameObject.tag == "quai")
        {
            Destroy(orther.gameObject);
          player.GetComponent<playerhealth>().UpdateHealth(+25);
        }
    }
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.tag == "quai")
        {
            Destroy(orther.gameObject);
        }
    }
}
