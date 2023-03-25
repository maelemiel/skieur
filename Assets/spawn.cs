using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube2 = GameObject.Find("cube");
        GameObject spike2 = GameObject.Find("spike");
        spike2.transform.position = GameObject.Find("spwan").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
                
    }
