using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float speed;
    private float speedonladder;
    private float jumpforce;
    private bool is_on_ground;
    private bool is_climb;
    private bool is_ladder;
    private float Horizontal;
    private float Vertical;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        speed = 0.2f;
        speedonladder = 0.01f;
        jumpforce = 3.6f;
        is_on_ground = false;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        transform.position = transform.position;

        if (is_ladder && Mathf.Abs(Vertical) > 0f)
            is_climb = true;
        if (Horizontal > 0.1f || Horizontal < -0.1f)
            rb2D.AddForce(new Vector2(Horizontal * speed, 0f), ForceMode2D.Impulse);
        if (!is_climb && !is_on_ground && Vertical > 0.1f)
            rb2D.AddForce(new Vector2(0f, Vertical * jumpforce), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if (is_climb) {
            rb2D.gravityScale = 0f;
            rb2D.velocity = new Vector2(rb2D.velocity.x, Vertical * speed * 10);
        } else {
            rb2D.gravityScale = 10f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            is_on_ground = false;
        if (collision.CompareTag("Ladder"))
            is_ladder = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            is_on_ground = true;
        if (collision.CompareTag("Ladder"))
            is_ladder = false;
            is_climb = false;
    }
}
