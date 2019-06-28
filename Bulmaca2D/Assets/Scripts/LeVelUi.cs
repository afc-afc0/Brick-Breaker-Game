using TMPro;
using UnityEngine;

public class LeVelUi : Singleton<LeVelUi>
{
    public TextMeshProUGUI OwnText;

    void Start()
    {
        OwnText.text = "LEVEL   " + GAME_MASTER.Instance.Level;  
    }

    void Update()   
    {
        OwnText.text = "LEVEL   " + GAME_MASTER.Instance.Level;
    }

}
