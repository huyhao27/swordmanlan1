using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : PlayerController
{
    GameObject GameController;
    public GameObject player;
    public GameObject danright, danleft;
    public Transform shootpoint;
    public bool right;
    public byte sodan;

    public object Private { get; private set; }
    //public GameObject dat2cd;
    public byte dem = 1;
    public byte speed;

    private void Start()
    {
        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
        right = true;
        sodan = 0;
    }
    private void OnCollisionExit2D(Collision2D orther)
    {
        if (orther.gameObject.CompareTag("cd"))
        {
            player.transform.parent = null;
        }
    }


    private void Update()
    {
        checkInput();

        if (m_rigidbody.velocity.magnitude > 30)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);

        }

    }

    public void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.S))  //아래 버튼 눌렀을때. 
        {

            IsSit = true;
            m_Anim.Play("Sit");


        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            m_Anim.Play("Idle");
            IsSit = false;

        }


        // sit나 die일때 애니메이션이 돌때는 다른 애니메이션이 되지 않게 한다. 
       /* if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Sit") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                    DownJump();
                
            }

            return;
        }*/


        m_MoveX = Input.GetAxis("Horizontal");


   
        GroundCheckUpdate();


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {


                m_Anim.Play("Attack");
                if (sodan > 0)
                {
                    sodan--;
                    shoot();
                }
            }
           /* else
            {

                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                        m_Anim.Play("Idle");

                }
                else
                {

                    m_Anim.Play("Run");
                }

            }*/
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
               m_Anim.Play("Die");
             Destroy(gameObject,0.7f);
            

        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;

            if (isGrounded)  // 땅바닥에 있었을때. 
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                transform.transform.Translate(Vector2.right* m_MoveX * MoveSpeed * Time.deltaTime);



            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }




            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.A))
                Filp(false);


        }
        else if (Input.GetKey(KeyCode.A))
        {
            right = false;

            if (isGrounded)  // 땅바닥에 있었을때. 
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;


                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }


            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.D))
                Filp(true);


        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                m_rigidbody.AddForce(Vector3.up * jumpForce);
                dem=2;
                isGrounded = false;
            }
            else if (isGrounded==false && dem ==2)
            {
                m_rigidbody.AddForce(Vector3.up * (jumpForce - 300));
                dem = 1;
            }
            /* if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                 return;


              if (currentJumpCount < JumpCount)  // 0 , 1
              {

                  if (!IsSit)
                  {
                      prefromJump();


                  }
                  else
                  {
                      DownJump();

                  }

              }*/


        }



    }
    
    public void shoot()
    {
        if(right)
        {
            Instantiate(danright, shootpoint.position, Quaternion.identity);
        }
        if (!right)
        {
            Instantiate(danleft, shootpoint.position, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D orther)
    {
        if (orther.gameObject.tag.Equals("trap"))
        {
           m_Anim.Play("Die");
            //Destroy(gameObject, 0.5f); 
        }
        else if (orther.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        else if (orther.gameObject.CompareTag("dan"))
        {
            sodan++;
            Destroy(orther.gameObject);
        }
        if (orther.gameObject.CompareTag("cd"))
        {
            isGrounded = true;
            player.transform.parent = orther.gameObject.transform;
        }
    }


   /* void EndGame()
    {
        GameController.GetComponent<gameController>().EndGame();
    }*/








    protected override void LandingEvent()
    {


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");

    }





}
