using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_add_power_up_scr : MonoBehaviour
{
    
    private string Ball_tag = "BALL";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Ball_tag) == true)
        {
            //Fire_point_scr.ball_num++;
         //   Debug.Log(Fire_point_scr.ball_num);
            Destroy(gameObject);
            return;
        }
    }

}
