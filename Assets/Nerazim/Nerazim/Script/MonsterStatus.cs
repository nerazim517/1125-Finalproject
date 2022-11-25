using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public int Monster_HP;
    public int Monster_Damage;
    public float Monster_Speed;
    // Start is called before the first frame update
    void Start()
    {
        Monster_HP = GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>().Get_Monster_HP(transform.tag);
        Monster_Damage = GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>().Get_Monster_Damage(transform.tag);
        Monster_Speed = GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>().Get_Monster_Speed(transform.tag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster_HP <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnDestroy()
    {
//        GameObject.FindWithTag("DataBase").GetComponent<Item_Database>().Spawn_Item(transform.tag,transform.position,transform.rotation);
    }
}
