using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_touch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 spawn = Vector3.zero;
            spawn.y = -4;
            collision.transform.position = spawn;
        }
    }
}
