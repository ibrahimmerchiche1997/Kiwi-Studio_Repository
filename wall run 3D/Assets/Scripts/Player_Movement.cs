using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Player_Movement : MonoBehaviour
{
    private Rigidbody playerbody;
   // public CharacterController character;
    public RopeSystem rs;
    public static float speed = 10;
    bool isRight, isLeft = true;
    public Animator Run;

    public Image power_bar;
    public Gradient gradient_Dec, gradient_Inc;
    bool DecreasingFirst = false;

    private Touch touch;

    public ParticleSystem SpeedEffect;

    private void Start()
    {
        playerbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (PlayingSystem.AllowToPlay)
        {

            if (!DecreasingFirst)
                DecreasingPower(8);


           // character.Move(transform.forward * speed * Time.deltaTime);
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.003f, transform.position.y + playerbody.velocity.y, transform.position.z + speed * Time.deltaTime);
                    if (touch.deltaPosition.x < 0)
                    {
                        transform.Rotate(0, -20 * Time.deltaTime, 0);
                    }
                    else if (touch.deltaPosition.x > 0)
                    {
                        transform.Rotate(0, 20 * Time.deltaTime, 0);
                    }
                }
            }

            {
                transform.position = new Vector3(transform.position.x, transform.position.y + playerbody.velocity.y, transform.position.z + speed * Time.deltaTime);

            }
        }


    }


    bool RightSides()
    {
        if (transform.position.x < 8)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    bool LeftSides()
    {

        if (transform.position.x > -8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Increasing Power-bar depending of time
    void IncreasingPower(float i)
    {
        Run.speed = 1.5f;
       
        power_bar.DOFillAmount(1, 0f).SetEase(Ease.Linear);
        power_bar.DOGradientColor(gradient_Inc, 0);
        DecreasingPower(i);
    }

    //Decreasing Power-bar depending of time
    void DecreasingPower(float t)
    {
        DecreasingFirst = true;
        power_bar.DOFillAmount(0, t).SetEase(Ease.Linear).OnComplete(() => Reset_Speed());
        power_bar.DOGradientColor(gradient_Dec, t);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedPower")
        {
            Speeds_Power(other.gameObject.name);
        }
        if (other.gameObject.tag == "Finish")
        {
            rs.Rope_Scaling_Up();
        }
        if (other.gameObject.tag == "Obstacles")
        {
         
            rs.Rope_Scaling_Down();
            StartCoroutine(SlowMotion());
           
        }
    }

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

    void Speeds_Power(string n)
    {
        SpeedEffect.gameObject.SetActive(true);
        switch (n)
        {
            case "LowSpeed": // Low speed
                speed = 45;
                IncreasingPower(4f);
                break;
            case "UltraSpeed": // Ultra speed
                speed = 80;
                IncreasingPower(8f);
                break;

        }
    }

    private void Reset_Speed()
    {
        speed = 20;
        SpeedEffect.gameObject.SetActive(false);
        Run.speed = 1f;
    }


   
}




