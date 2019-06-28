using UnityEngine;

public class Slider_scr : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 dest;
    private bool is_moving = false;
    public bool Destroy_after_slide = false;
    private string boxTag = "BOX";
    [SerializeField] private float speed = 4f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(is_moving == true &&  Mathf.Abs(transform.position.y - dest.y) <= 0.3f)
        {
            is_moving = false;
            rb2d.velocity = Vector2.zero;
            rb2d.position = dest;
            if(Destroy_after_slide == true)
            {
                Destroy(gameObject);
                return;
            }
        }

        if(is_moving == true)
        {
            if(gameObject.CompareTag(boxTag) && gameObject.transform.position.y < SetFirePosition.Instance.LaunchPosition().y + 3f)
            {
                GAME_MASTER.Instance.GameOver();
            }
        }

    }


    public void Slide_down()
    {
        is_moving = true;
        dest = (Vector2)transform.position + (3 * Vector2.down);
        rb2d.velocity = Vector2.down * speed;
    }

}
