using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Obstacles_System Os;



    private Rigidbody playerbody;
    public float movespeed ;
    private bool IsRunning;
    private Touch touch;
    //public Animator anim;
    void Start()
    {Debug.Log("ffffff");
        playerbody = GetComponent<Rigidbody>();
     //   anim = GetComponent<Animator>();
    }

   
    void FixedUpdate()
    {
        if(Input.touchCount == 0)
        {
        //    anim.SetFloat("Left", 1);
         //   anim.SetFloat("Right", -1);
        }
        
        if (Input.touchCount > 0)
        {     touch = Input.GetTouch(0);
          if (touch.phase == TouchPhase.Moved)
          {
             transform.position = new Vector3(transform.position.x + touch.deltaPosition.x*0.003f, transform.position.y + playerbody.velocity.y, transform.position.z + movespeed * Time.deltaTime);
          if(touch.deltaPosition.x < 0)
                {
                     transform.Rotate(0, -20 * Time.deltaTime, 0);
                   
                       
                   // anim.SetFloat("Left", touch.deltaPosition.x);
                  //  anim.SetFloat("Right", -1);
                }
          else if(touch.deltaPosition.x > 0)
                {
                    transform.Rotate(0, 20 * Time.deltaTime, 0);
                  //  anim.SetFloat("Right", touch.deltaPosition.x);
                  //  anim.SetFloat("Left", 1);
                }
          }
        }

        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerbody.velocity.y, transform.position.z + movespeed * Time.deltaTime);
          //  anim.SetBool("left",false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ssszzzzz");
        //if (other.gameObject.tag == "SpeedPower")
        //{
        //    Speeds_Power(other.gameObject.name);
        //}
        //if (other.gameObject.tag == "Finish")
        //{
        //    rs.Rope_Scaling_Up();
        //}
        if (other.gameObject.tag == "Obstacles")
        {
            Os.DestroyObstacle(other.transform);
            Debug.Log("sss");
            // rs.Rope_Scaling_Down();
            StartCoroutine(SlowMotion());

        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Obstacles")
    //    {
        

    //        // rs.Rope_Scaling_Down();
    //        StartCoroutine(SlowMotion());

    //    }
    //}
    IEnumerator SlowMotion()
    {
        int timescaling = 1;
        while (timescaling > 0)
        {
            Time.timeScale = 0.2f;
            yield return new WaitForSeconds(.2f);
            Time.timeScale = 1f;
            Debug.Log("gg");
            timescaling--;
        }

    }

}
