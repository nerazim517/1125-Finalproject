using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform mon;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject.FindWithTag("FollowCamera").GetComponent<CinemachineFreeLook>().Follow = mon;
        GameObject.FindWithTag("FollowCamera").GetComponent<CinemachineFreeLook>().LookAt = mon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
