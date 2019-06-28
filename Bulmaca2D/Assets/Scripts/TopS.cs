using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopS : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rgbd2d;
    private bool MoveToLaunchPos = false;

    /*void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("velocity : " + rgbd2d.velocity);
        if(MoveToLaunchPos == true && Vector2.Distance(rgbd2d.position,SetFirePosition.Instance.LaunchPosition2d()) > 0.2f)
        {
            Debug.Log("updating MoveTo");
            MoveToLaunchPos = false;
            rgbd2d.velocity = Vector2.zero;
            rgbd2d.transform.position = SetFirePosition.Instance.LaunchPosition2d();
        }
    }

    public void Launch(Vector2 dir)
    {
        rgbd2d.velocity = dir.normalized * speed;
    }

    public void MoveTo(Vector2 pos)
    {
        MoveToLaunchPos = true;
        Vector2 dir; 
        dir.x = pos.x - transform.position.x;
        dir.y = pos.y - transform.position.y;

        rgbd2d.velocity = dir.normalized * speed;
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    public Vector2 GetPos()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        Launch(Vector2.up);
    }
    */
}
