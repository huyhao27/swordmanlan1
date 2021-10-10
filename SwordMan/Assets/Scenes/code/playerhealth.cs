using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour{
    GameObject GameController;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healhSlider;
    protected Animator m_Anim;
    private void Start()
    {
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        health = maxHealth;
        healhSlider.maxValue = maxHealth;
    }
    private void Update()
    {
        if (health == 0)
        {
            m_Anim.Play("Die");
            Destroy(gameObject, 0.7f);
        }
    }
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }else if (health <= 0f)
        {
            health = 0f;
            // player die
        }
    }
    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        healhSlider.value = Mathf.Lerp(healhSlider.value, health, t);
    }
    private void OnCollisionEnter2D(Collision2D orther)
    {
        if(orther.gameObject.tag == "trap")
        {
            health = 0;
        }
       else if (orther.gameObject.tag == "hp")
        {
            health += 25;
            Destroy(orther.gameObject);
        }
    }
}
