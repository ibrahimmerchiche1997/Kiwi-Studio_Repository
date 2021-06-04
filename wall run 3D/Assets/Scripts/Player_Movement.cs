using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Player_Movement : MonoBehaviour
{
    public CharacterController character;
    public RopeSystem rs;
    public static float speed = 80;
    bool isRight, isLeft = true;
    public Animator Run;

    public Image power_bar;
    public Gradient gradient_Dec, gradient_Inc;
    bool DecreasingFirst = false;

    Touch touch;

    public ParticleSystem SpeedEffect;

    private void Start()
    {
        
    }

    private void Update()
    {

        if (PlayingSystem.AllowToPlay)
        {

            if (!DecreasingFirst)
                DecreasingPower(8);


            character.Move(transform.forward * speed * Time.deltaTime);
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        if (touch.position.x < Screen.width / 2 && LeftSides())
                        {
                            transform.position = new Vector3(transform.position.x - 8f, transform.position.y, transform.position.z);
                        }
                        else if (touch.position.x > Screen.width / 2 && RightSides())
                        {
                            transform.position = new Vector3(transform.position.x + 8f, transform.position.y, transform.position.z);
                        }
                    }

                }
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
            Debug.Log("gg");
        }
    }

    IEnumerator SlowMotion()
    {
        int timescaling = 1;
        while (timescaling > 0)
        {
            Time.timeScale = 0.2f;
            yield return new WaitForSeconds(.1f);
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




