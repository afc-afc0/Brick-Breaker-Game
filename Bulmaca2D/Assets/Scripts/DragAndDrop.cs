using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Canvas))]
public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private LineRenderer lin;
    private bool is_dragging;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector2 current;
    private Vector3 camera_off_set = new Vector3(0f, 0f, 30f);
    private Vector2 final_vec;
    public static bool enable_ui = false;

    public static DragAndDrop _instance;

    public static DragAndDrop Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("DragAndDrop");
                go.AddComponent<DragAndDrop>();
            }

            return _instance;
        }

    }

    void Awake()
    {
        _instance = this;
        lin.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enable_ui)
        {
            lin.enabled = true;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
        }
        if (Input.GetMouseButton(0) && enable_ui)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
            Launch_line(endPos - startPos);
        }
        if (Input.GetMouseButtonUp(0) && enable_ui)
        {
            final_vec = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
            Ball_control.Instance.Launch_ball(final_vec);
            lin.enabled = false;
            enable_ui = false;
        }
    }



    void Launch_line(Vector3 vec)
    {
        if (lin == null)
            lin = new LineRenderer();

        lin.SetPosition(0, GAME_MASTER.Instance.Fire_p.transform.position);
        lin.SetPosition(1, GAME_MASTER.Instance.Fire_p.transform.position - vec + camera_off_set);
    }

    private Vector3 GetTouchPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, Camera.main.transform.position.z));
    }
}


/*
 * 
 * using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Canvas))]
public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private LineRenderer lin;
    private bool is_dragging;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector2 current;
    private Vector3 camera_off_set = new Vector3(0f, 0f, 30f);
    private Vector2 final_vec;
    public static bool enable_ui = false;

    public static DragAndDrop _instance;
    
    public static DragAndDrop Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("DragAndDrop");
                go.AddComponent<DragAndDrop>();
            }

            return _instance;
        }

    }

    void Awake()
    {
        _instance = this;
        lin.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enable_ui)
        {
            lin.enabled = true;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
        }
        if (Input.GetMouseButton(0) && enable_ui)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
            Launch_line(endPos - startPos);
        }
        if (Input.GetMouseButtonUp(0) && enable_ui)
        {
            final_vec = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
            Ball_control.Instance.Launch_ball(final_vec);
            lin.enabled = false;
            enable_ui = false;
        }
    }



    void Launch_line(Vector3 vec)
    {
        if (lin == null)
            lin = new LineRenderer();

        lin.SetPosition(0, GAME_MASTER.Fire_p.transform.position);
        lin.SetPosition(1, GAME_MASTER.Fire_p.transform.position - vec + camera_off_set);
    }

    private Vector3 GetTouchPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, Camera.main.transform.position.z));
    }
}


    */
