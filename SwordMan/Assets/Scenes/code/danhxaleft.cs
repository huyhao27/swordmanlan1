using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danhxaleft : MonoBehaviour
{
    public float speed;
    public float TimeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
