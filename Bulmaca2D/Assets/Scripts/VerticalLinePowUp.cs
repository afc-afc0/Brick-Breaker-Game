using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLinePowUp : MonoBehaviour
{
    public Renderer VerticalLine;
    [SerializeField] private float flashTimer = 0.3f;


    void Start()
    {
        VerticalLine.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Ball_scr ball = col.GetComponent<Ball_scr>();
        if(ball != null)
        {
            gameObject.GetComponent<Slider_scr>().Destroy_after_slide = true;
            StartCoroutine(Flash());
            BlockControl.Instance.HitBlocksVertical(gameObject.transform.position.y);
        }
    }

    private IEnumerator Flash()
    {
        VerticalLine.enabled = true;
        yield return new WaitForSeconds(flashTimer);
        VerticalLine.enabled = false;
    }

}
