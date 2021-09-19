using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dat2cd : MonoBehaviour
{
    public float dau, cuoi;
    public float speed;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        //speed = -4;
    }

    // Update is called once per frame
   
    void Update()
    {
        obj.transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));

    }
   private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.tag.Equals("dau"))

            speed = -speed;

        else if (orther.gameObject.tag.Equals("cuoi"))
            speed = -speed;

    }



}

