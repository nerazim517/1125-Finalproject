using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float HP;
    public float MP;
    public float Shield;
    public float InitHP = 1000;
    public float InitMP = 200;
    // Start is called before the first frame update
    void Start()
    {
        HP = 0;
        Shield = 500;
        MP = InitMP;
    }

    // Update is called once per frame
    void Update()
    {
        HP++;
        if (HP >= 1000)
        {
            HP = 1000;
        }
    }
}
