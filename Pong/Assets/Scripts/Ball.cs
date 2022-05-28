using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 startPosition;

    private float x;
    private float y;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    private void Launch()
    {
        //   float x = Random.Range(0, 2) == 0 ? -1 : 1;

        if (Random.Range(0, 2) == 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }

        if (Random.Range(0, 2) == 0)
        {
            y = -1;
        }
        else
        {
            y = 1;
        }

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    void Update()
    {
        // increase the speed of the ball movement over time
        rb.AddForce(rb.velocity * speed * Time.deltaTime);
        // print(rb.velocity);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
}
