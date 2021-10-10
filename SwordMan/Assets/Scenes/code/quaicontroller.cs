using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaicontroller : MonoBehaviour
{
    public float dan;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    //public float lookRadius = 10f; 
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerhealth>().UpdateHealth(-attackDamage);
        }
    }
    private void OnCollisionStay2D(Collision2D orther)
    {
        if (orther.gameObject.tag == "Player")
        {
            
           if (attackSpeed <= canAttack)
            {
                canAttack = 0f;
                orther.gameObject.GetComponent<playerhealth>().UpdateHealth(-attackDamage);
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }


    /* void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, lookRadius);
     }*/

}
