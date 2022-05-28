using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Paddle : MonoBehaviour
{
    public AudioSource BallCollision;
    public AudioSource WallCollision;
    public bool isPlayer1;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
//    public Vector3 startPosition;

    private float movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BallCollision = GetComponent<AudioSource>();
        //        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BallCollision.Play();
        }
        if (collision.gameObject.tag == "Wall"){
            WallCollision.Play();
        }
    }

    /*  public void Reset()
       {
           rb.velocity = Vector2.zero;
           transform.position = startPosition;
       }
       */
}
