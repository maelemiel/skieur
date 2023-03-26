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
        speedonladder = 3f;
        jumpforce = 4f;
        is_on_ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        transform.position = transform.position;

        if (is_ladder && Mathf.Abs(Vertical) > 0f) {
            is_climb = true;
            animator.SetBool("is_climb", true);
        } else {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        if (Horizontal > 0.1f || Horizontal < -0.1f)
            rb2D.AddForce(new Vector2(Horizontal * speed, 0f), ForceMode2D.Impulse);
        if (!is_climb && !is_on_ground && Vertical > 0f)
            rb2D.AddForce(new Vector2(0f, Vertical * jumpforce), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if (is_climb) {
            rb2D.gravityScale = 0f;
            rb2D.velocity = new Vector2(rb2D.velocity.x, Vertical * speedonladder);
        } else {
            rb2D.gravityScale = 10f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Rampe")
            is_on_ground = false;
        if (collision.gameObject.tag == "Rampe") {
            rb2D.mass = 4f;
            speed = 7f;
            animator.SetBool("Ski", true);
        }
        if (collision.CompareTag("Ladder")) {
            is_ladder = true;
            animator.SetBool("is_climb", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Rampe")
            is_on_ground = true;
        if (collision.gameObject.tag == "Rampe") {
            speed = 0.2f;
            rb2D.mass = 2f;
            animator.SetBool("Ski", false);
        }
        if (collision.CompareTag("Ladder")) {
            animator.SetBool("is_climb", false);
            is_ladder = false;
            is_climb = false;
        }
    }
}
