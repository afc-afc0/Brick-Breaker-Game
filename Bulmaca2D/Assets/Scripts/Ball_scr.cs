using UnityEngine;

public class Ball_scr : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    public bool move_to_controller = false;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(move_to_controller && Vector2.Distance(transform.position,SetFirePosition.Instance.LaunchPosition2d()) <= 0.7f && transform.position != SetFirePosition.Instance.LaunchPosition())
        {
            move_to_controller = false;
            Ball_control.Instance.fallen_balls++;
            Stop_ball();
            rb2d.position = SetFirePosition.Instance.LaunchPosition2d();
        }
    }

    public void Launch(Vector2 direction)
    {
        rb2d.velocity = direction * speed ;
    }

    public void Stop_ball()
    {
        rb2d.velocity = Vector2.zero;
    }


    public void ChangeMovementRandomly()
    {
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 2f)).normalized;
        rb2d.velocity = randomVector * speed;
    }

    public void Move_to(Transform dest)
    {
        move_to_controller = true;
        rb2d.velocity = speed * (dest.position - transform.position).normalized;
    }

    public void Move_to(Vector2 dest)
    {
        move_to_controller = true;
        Vector2 temp;
        temp.x = dest.x - transform.position.x;
        temp.y = dest.y - transform.position.y;
        rb2d.velocity = speed / 3 * temp.normalized;
    }

    public void SetPosition(Vector3 place)
    {
        gameObject.transform.position = place;
    }


}
