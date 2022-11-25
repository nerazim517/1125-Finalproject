using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject Bullet;
    private bool CanJump;
    
    // Start is called before the first frame update
    void Start()
    {
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(1,0,0)*Time.deltaTime*speed;
            if (Input.GetKey(KeyCode.Space)&&CanJump)
            {
                CanJump = false;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(0,0,1)*Time.deltaTime*speed;
            if (Input.GetKey(KeyCode.Space)&&CanJump)
            {
                CanJump = false;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= new Vector3(1,0,0)*Time.deltaTime*speed;
            if (Input.GetKey(KeyCode.Space)&&CanJump)
            {
                CanJump = false;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position -= new Vector3(0,0,1)*Time.deltaTime*speed;
            if (Input.GetKey(KeyCode.Space)&&CanJump)
            {
                CanJump = false;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);
            }
        }
        else if (Input.GetKey(KeyCode.Space)&&CanJump)
        {
            CanJump = false;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GameObject Bullet_ = Instantiate(Bullet, this.transform.position+new Vector3(2,0,0), this.transform.rotation);
            Bullet_.GetComponent<Rigidbody>().velocity = this.transform.right * 50f;
            Destroy(Bullet_,5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            CanJump = true;
        }
    }
}
