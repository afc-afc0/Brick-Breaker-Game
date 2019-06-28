using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    private string LevelOne = "Level1";
    private string LevelTwo = "Level2";
    private string LevelThree = "Level3";
    private string LevelFour = "Level4";
    private string LevelFive = "Level5";
    private string LevelSix = "Level6";
    private string MainMenuName = "MainMenu";

    public void LoadLevelOne()
    {
        Debug.Log(LevelOne);
        SceneManager.LoadScene(LevelOne);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(LevelTwo);
    }
    public void LoadLevelThree()
    {
        Debug.Log(LevelThree);
        SceneManager.LoadScene(LevelThree);
    }

    public void LoadLevelFour()
    {
        Debug.Log(LevelFour);
        SceneManager.LoadScene(LevelFour);
    }

    public void LoadLevelFive()
    {
        Debug.Log(LevelFive);
        SceneManager.LoadScene(LevelFive);
    }

    public void LoadLevelSix()
    {
        Debug.Log(LevelSix);
        SceneManager.LoadScene(LevelSix);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }

}
