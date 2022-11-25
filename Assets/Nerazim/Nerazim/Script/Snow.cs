using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject.FindWithTag("DataBase").GetComponent<Item_Database>().PutItemIntoBackpack(this.transform.tag);
            Destroy(this.gameObject);
        }
    }
}
