using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float speed = 10f;
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
    }
}
