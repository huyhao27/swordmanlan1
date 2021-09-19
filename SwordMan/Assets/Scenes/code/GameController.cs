/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public bool isEndgame;
    protected Animator m_Anim;

    // Start is called before the first frame update
    void Start()
    {
        isEndgame = false;
        m_Anim = this.transform.Find("model").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EndGame()
    {
        isEndgame = true;
        m_Anim.Play("Die");
        Destroy(gameObject, 0.5f);
    }
}*/
