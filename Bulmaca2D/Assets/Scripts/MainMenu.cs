using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string sceneName = "LevelSelectMenu";
    [SerializeField] private string thankYouScene = "";

    public void LevelSelectScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ThankYouScene()
    {
        Debug.Log("Thank You");
        SceneManager.LoadScene(thankYouScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

}
