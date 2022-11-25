using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController Controller;
    public Transform cam;
    public Transform ori;
    public Transform playerObj;
    public Rigidbody rb;

    public float speed = 6f;
    public float rotationSpeed = 7f;
    public float jumpForce = 5f;
    void Start()
    {
        //Controller = GetComponent<CharacterController>();
        ori = transform.GetChild(0).gameObject.transform;
        playerObj = transform.GetChild(1).gameObject.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //方向
        Vector3 viewDir = transform.position - new Vector3(cam.position.x, transform.position.y, cam.position.z);
        ori.forward = viewDir.normalized;
        //input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //input with 方向
        Vector3 inputDir = ori.forward * v + ori.right * h;
        //跳
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, 1f, 0f) * jumpForce, ForceMode.Impulse);
        }
        // 照方向移動
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            rb.velocity = new Vector3(inputDir.x * speed, rb.velocity.y, inputDir.z * speed);
            //Controller.Move(inputDir * speed * Time.deltaTime);
        }
    }
}
