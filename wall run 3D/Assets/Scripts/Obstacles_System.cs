using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obstacles_System : MonoBehaviour
{

    public float time;
    public static  bool isPushed;


    // Start is called before the first frame update
    void Start()
    {
   
        Obstacles_ID(transform.name);
    }

   

    public void Obstacles_ID(string n)
    {
        switch (n)
        {
            case "Obstacles_MoverX_positive":
                Obstacles_MoverX(transform);
                break;
            case "Obstacles_MoverX_negative":
                Obstacles_MoverX(transform);
                break;
            case "Obstacles_Static_Cylinder":
                break;
           
    
    }
    }

    private void Obstacles_MoverX(Transform obs)
    {
  
        if(obs.name== "Obstacles_MoverX_positive")
            obs.DOMoveX(obs.transform.position.x - 3f, time).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo);
           
        if(obs.name== "Obstacles_MoverX_negative")
            obs.DOMoveX(obs.transform.position.x + 3f, time).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo);

       
    }

    private void Obstacles_StaticCylinder(Transform obs)
    {
        for (int i = 0; i < obs.transform.childCount; i++)
        {
            obs.gameObject.AddComponent<Rigidbody>().AddForce(Vector3.forward * .5f);
        }
    }

    private void Obstacles_Jumper(Transform obs)
    {
        for (int i = 0; i < obs.transform.childCount; i++)
        {
            obs.gameObject.AddComponent<Rigidbody>().AddForce(Vector3.forward * .5f);
        }
    }

    private void Obstacles_Door()
    {
        if (isPushed)
        {
            transform.DOMoveX(transform.position.x - 5, time);
            //Play audio openning door
        }else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                gameObject.AddComponent<Rigidbody>().AddForce(Vector3.forward * .5f);
            }
        }

       
    }


    public void Push(Transform obs)
    {
        isPushed = true;
        Obstacles_Door();
        obs.DOMoveY(obs.transform.position.y - 1,.2f);
        //play audio push
    }


    public void DestroyObstacle(Transform col)
    {
        Vector3 explosionPosition = col.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, 5);
        foreach (Collider hit in colliders)
        {

            if (hit.gameObject.tag == "Obstacles")
            {
                if (hit.GetComponent<Rigidbody>() == null)
                {
                    hit.gameObject.AddComponent<Rigidbody>().AddExplosionForce(1, explosionPosition, 1, .1f, ForceMode.Impulse);
                    Debug.Log(hit.name);
                }
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1, explosionPosition, 1, .1f, ForceMode.Impulse);
            }



        }
    }
}
