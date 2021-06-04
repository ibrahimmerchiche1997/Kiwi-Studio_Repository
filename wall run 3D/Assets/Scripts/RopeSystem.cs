using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSystem : MonoBehaviour
{
    public GameObject Hand_Right;
    public GameObject Rope;
    public int init_value = 10;



    public float value = 0.1f;
    float ScaleZ = 0.2f;

    private void Start()
    {

        //  Rope_Instanting();
    }
    public void Rope_Scaling_Up()
    {
        Rope.transform.localScale = new Vector3(Rope.transform.localScale.x, ScaleZ, Rope.transform.localScale.z);
        ScaleZ = ScaleZ + value;
    }

    public void Rope_Scaling_Down()
    {
        float y = Rope.transform.localScale.y - value;
        Rope.transform.localScale = new Vector3(Rope.transform.localScale.x, y, Rope.transform.localScale.z);
    }



}
