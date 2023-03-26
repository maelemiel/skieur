using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawn2;
    public GameObject spike;
    public GameObject cube;
    private GameObject newObject;
    private int rand;
    private double time;
    int test;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 0.001;
        if (time >= 1)
        {
            creat_obstacle();
            time = 0;
        }
        print(time);
    }
    void creat_obstacle()
    {
        rand = Random.Range(0, 3);
        if (rand == 1)
        {
            newObject = Instantiate(spike);
            newObject.transform.position = spawn2.transform.position;
        }
        if (rand == 2)
        {
            newObject = Instantiate(cube);
            newObject.transform.position = spawn2.transform.position;
        }
    }
}
