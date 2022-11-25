using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach (string Monster_name in GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>()
                     .Monster_List)
        {
            if (collision.transform.tag == Monster_name)
            {
                collision.transform.GetComponent<MonsterStatus>().Monster_HP -= 5;
                Destroy(this.gameObject);
            }
        }
        
        
    }
}
