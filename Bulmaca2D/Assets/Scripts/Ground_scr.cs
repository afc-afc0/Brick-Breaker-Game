using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_scr : Singleton<Ground_scr>
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Ball_scr ball = other.GetComponent<Ball_scr>();
        if (ball != null)
        {
            ball.Stop_ball();
            ball.Move_to(SetFirePosition.Instance.LaunchPosition2d());
        }
    }

}
