using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danhxa : MonoBehaviour
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
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

}
