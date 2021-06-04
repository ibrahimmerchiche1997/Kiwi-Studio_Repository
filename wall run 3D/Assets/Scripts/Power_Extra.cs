using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Power_Extra : MonoBehaviour
{










    // Start is called before the first frame update
    void Start()
    {
        Get_ID(transform.name);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" || other.gameObject.tag == "Enemy")
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        }
    }





   

 


    void Get_ID(string n)
    {
        switch (n)
        {
            case "RotatingLinearOBS":
                Rotating_Linear();
                break;
            case "RotatingCircleOBS":
                Rotating_Circle();
                break;
        }
    }

   
    void Rotating_Linear()
    {
        transform.DORotate(new Vector3(0, 270, 0), 1.2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
    private void Rotating_Circle()
    {
        transform.DORotate(new Vector3(0, 270, 0), 1.2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

}


