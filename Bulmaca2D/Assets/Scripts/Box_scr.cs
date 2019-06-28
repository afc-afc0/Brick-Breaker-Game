using UnityEngine;
using TMPro;

public class Box_scr : MonoBehaviour
{
    [SerializeField]
    private int life;
    [SerializeField]
    private string Ball_tag = "BALL";
    [SerializeField] private Material own_met;
    [SerializeField]
    private TextMeshProUGUI life_txt;


    void Start()
    {
        life_txt = GetComponentInChildren<TextMeshProUGUI>();
        life = GAME_MASTER.Instance.Level;
        if(Random.Range(0f,100f) > 95f)//2x life %5   change
        {
            life = life * 2;
        }
        life_txt.text = life.ToString();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag(Ball_tag) == true)
        {
            GetHit();
            PointUi.Instance.ScoreUpdate(1);
        }
    }

    public void GetHit()
    {
        life--;
        if(life <= 0)
        {
            Destroy(gameObject);
            return;
        }
        UpdateText();
    }

    void UpdateText()
    {
        life_txt.text = life.ToString();
    }

    public Vector2 Get_pos()
    {
        return transform.position;
    }

    void OnDestroy()
    {
        BlockControl.blockCount--;
    }
    
}
