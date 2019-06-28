using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrow : Singleton<LaunchArrow>
{


    [SerializeField] private LineRenderer lin;

    public static bool isLaunching;
    public Vector3 touch_pos;
    private Vector3 camera_off_set;
    private Vector3 for_0_position_off_set = new Vector3(0f,0f,-22f);
    private Vector3 launchPos;
    private Vector2 fireVec;
    private Vector3 dir;
    

    void Awake()
    {
        lin.positionCount = 2;
        camera_off_set = new Vector3(0f, 0f, -Camera.main.transform.position.z);
        isLaunching = true;
        InvokeRepeating("ControlIsLaunching",0f,1.5f);
    }

    void ControlIsLaunching()
    {
        if(GAME_MASTER.Instance.stageFindingFirePlace == true)
        {
            isLaunching = true;
        }
    }


    void OnMouseDown()
    {
        if(isLaunching)
        {
            lin.enabled = true;
            lin.SetPosition(0,SetFirePosition.Instance.LaunchPosition());
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
            dir = touch_pos - SetFirePosition.Instance.LaunchPosition();
            dir = dir * 3;
            lin.SetPosition(1, dir);
        }
    }


    void OnMouseDrag()
    {
        if(isLaunching)
        {
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
            if(Vector3.Distance(touch_pos,SetFirePosition.Instance.LaunchPosition()) > 3)
            {
                dir = touch_pos - SetFirePosition.Instance.LaunchPosition();
                dir = dir * 3;
            }
            else
            {
                lin.enabled = false;
            }
            lin.SetPosition(1, dir);
        }
    }

    void OnMouseUp()
    {
        if(isLaunching  && lin.enabled)
        {
            touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + camera_off_set);
            Ball_control.Instance.StartLaunching(lin.GetPosition(1) - lin.GetPosition(0));
            GAME_MASTER.Instance.StagePlaying();
            lin.enabled = false; 
        }
    }

}