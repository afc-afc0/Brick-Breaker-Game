using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLinePowUp : MonoBehaviour
{
    public Renderer HorizontalLine;
    [SerializeField] private float flashTimer = 0.3f;


    void Start()
    {
        HorizontalLine.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Ball_scr ball = col.GetComponent<Ball_scr>();
        if (ball != null)
        {
            gameObject.GetComponent<Slider_scr>().Destroy_after_slide = true;
            StartCoroutine(Flash());
            BlockControl.Instance.HitBlocksHorizontal(gameObject.transform.position.x);
        }
    }

    private IEnumerator Flash()
    {
        HorizontalLine.enabled = true;
        yield return new WaitForSeconds(flashTimer);
        HorizontalLine.enabled = false;
    }
}
