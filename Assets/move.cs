using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public GameObject spawn;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = spawn.transform.position;
    }
    void FixedUpdate()
    {
        float horizontal_move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 target_velocity = new Vector2(horizontal_move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, target_velocity, ref velocity, .05f);
    }
    // Update is called once per frame
}
