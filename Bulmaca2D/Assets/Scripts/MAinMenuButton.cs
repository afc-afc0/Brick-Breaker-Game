using UnityEngine.SceneManagement;
using UnityEngine;

public class MAinMenuButton : MonoBehaviour
{
    
    public void LoadMainMenu()
    {
        GAME_MASTER.Instance.GameOver();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
