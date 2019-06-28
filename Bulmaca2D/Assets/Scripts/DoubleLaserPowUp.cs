using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLaserPowUp : MonoBehaviour
{

    [SerializeField] private Renderer horizontal;
    [SerializeField] private Renderer vertical;
    [SerializeField] private float flashTimer = 0.4f;

    void Start()
    {
        horizontal.enabled = false;
        vertical.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Ball_scr ball = col.GetComponent<Ball_scr>();
        if (ball != null)
        {
            gameObject.GetComponent<Slider_scr>().Destroy_after_slide = true;
            StartCoroutine(Flash());
            BlockControl.Instance.HitBlocksHorizontalAndVertical(transform.position);
        }
    }

    private IEnumerator Flash()
    {
        horizontal.enabled = true;
        vertical.enabled = true;
        yield return new WaitForSeconds(flashTimer);
        vertical.enabled = false;
        horizontal.enabled = false;
    }

}
