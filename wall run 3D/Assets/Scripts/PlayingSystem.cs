using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class PlayingSystem : MonoBehaviour
{
    public Player_Movement pm;

    public static bool AllowToPlay = false;
  




    //-------- Timer Variables -------\\
    public Text Start_Playing;
    [SerializeField] GameObject Background_Chrono;
    float currCountDown;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());

    }

    // Update is called once per frame
    void Update()
    {



    }



    // Update the the timer text & effects
    void Timer_Effects(float t)
    {
        switch ((int)t)
        {
            case 3:
                Start_Playing.text = t.ToString("0");
                Start_Playing.transform.DOScale(new Vector3(1.7813f, 1.7813f, 1.7813f), .5f).SetEase(Ease.OutBounce).OnComplete(() => Start_Playing.transform.DOScale(new Vector3(0f, 0f, 0f), .5f));
                break;
            case 2:
                Start_Playing.text = t.ToString("0");
                Start_Playing.transform.DOScale(new Vector3(1.7813f, 1.7813f, 1.7813f), .5f).SetEase(Ease.OutBounce).OnComplete(() => Start_Playing.transform.DOScale(new Vector3(0f, 0f, 0f), .5f));
                break;
            case 1:
                Start_Playing.text = t.ToString("0");
                Start_Playing.transform.DOScale(new Vector3(1.7813f, 1.7813f, 1.7813f), .5f).SetEase(Ease.OutBounce).OnComplete(() => Start_Playing.transform.DOScale(new Vector3(0f, 0f, 0f), .5f));
                break;
            case 0:
                Start_Playing.text = "Go!";
                Start_Playing.transform.DOScale(new Vector3(1.7813f, 1.7813f, 1.7813f), .5f).SetEase(Ease.OutBounce).OnComplete(() => Start_Playing.transform.DOScale(new Vector3(0f, 0f, 0f), .5f));
                break;
        }

    }


    // Timer for start playing
    IEnumerator Timer(float countmax = 3)
    {
        currCountDown = countmax;
        while (currCountDown >= 0)
        {
            Timer_Effects(currCountDown);
            yield return new WaitForSeconds(1f);
            currCountDown--;
        }
        Background_Chrono.SetActive(false);
        AllowToPlay = true;
        pm.Run.SetBool("AllowToRun", AllowToPlay);

    }
}
