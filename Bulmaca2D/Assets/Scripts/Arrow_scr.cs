using UnityEngine;

public class Arrow_scr : MonoBehaviour
{
    private Vector3 upper_position = new Vector3(0f,0.5f,0f);
    private Vector3 world_pos;

    private static Arrow_scr _instance;

    public static Arrow_scr Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Arrow_scr");
                go.AddComponent<Arrow_scr>();
            }

            return _instance;
        }


    }

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if(_instance == null)
        {
            Debug.Log("err");
        }
    }

    public Vector3 Get_pos()
    {
        return upper_position + gameObject.transform.position;
    }

}
