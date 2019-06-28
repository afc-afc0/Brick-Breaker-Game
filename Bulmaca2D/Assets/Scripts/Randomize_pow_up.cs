using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize_pow_up : MonoBehaviour
{
    private string BALL_tag = "BALL";

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag(BALL_tag) == true)
        {
            col.gameObject.GetComponent<Ball_scr>().ChangeMovementRandomly();
            gameObject.GetComponent<Slider_scr>().Destroy_after_slide = true;
        }
    }
}
