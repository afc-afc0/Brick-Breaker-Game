using UnityEngine;

public class SetFirePosition : MonoBehaviour
{
    public static bool setting_position = true;
    private Vector3 camera_offset = new Vector3(0f,0f,30f);
    [SerializeField] private GameObject arrow;
    private Vector3 touch_pos;
    private Vector2 arrow_position = new Vector2(0f,0f);
    private Vector2 up_vec = new Vector2(0f,2.5f);
    [SerializeField] private Transform ball_pos;
    public int online_balls;

    private static SetFirePosition _instance;

    public static SetFirePosition Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("SetFirePosition");
                go.AddComponent<SetFirePosition>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public Vector3 LaunchPosition()
    {
        return ball_pos.position;
    }

    public Vector2 LaunchPosition2d()
    {
        return ball_pos.position;
    }

    public void SettingFirePosition()
    {
        setting_position = true;
    }

    void OnMouseDown()
    {
        if (setting_position)
        {
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_offset);
            arrow.transform.position = new Vector3(touch_pos.x, arrow.transform.position.y, arrow.transform.position.z);
        }
    }

    void OnMouseDrag()
    {
        if (setting_position)
        {
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_offset);
            arrow.transform.position = new Vector3(touch_pos.x, arrow.transform.position.y, arrow.transform.position.z);
        }
    }

    void OnMouseUp()
    {
        if (setting_position)
        {
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_offset);
            arrow.transform.position = new Vector3(touch_pos.x, arrow.transform.position.y, arrow.transform.position.z);
        }
    }

}
