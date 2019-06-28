using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_MASTER : Singleton<GAME_MASTER>
{
    public string Ball_tag = "BALL";
    public GameObject Fire_p;
    public int Level  = 1;
    public bool first_ball_hit_ground = false;
    public Vector2 fire_position;
    public bool level_ended = false;
    public bool stagePlaying;
    [SerializeField]public bool stageFindingFirePlace;
 

    void Awake()
    { 
        if (instance == null)
        {
            instance = this;
        }
    }

   

    public void InvokeLevelUp()
    {
        Invoke("LevelUp",2f);
    }

    public void LevelUp()
    {
        Level++;
        BlockControl.Instance.SlideDownObjects();
        BlockControl.Instance.SpawnBlocks();
        StageFindingFirePlace();
    }
        
    public void StagePlaying()
    {
        stagePlaying = true;
        stageFindingFirePlace = false;
        SetFirePosition.setting_position = false;
        LaunchArrow.isLaunching = false;
    }

    public void StageFindingFirePlace()
    {
        stageFindingFirePlace = true;
        stagePlaying = false;
        DownBalls.Instance.DisableButton();
        Ball_control.Instance.OnLevelEnd();
        SetFirePosition.Instance.SettingFirePosition();
        LaunchArrow.isLaunching = true;
    }

    public void GameOver()
    {
        Level = 1;
        SceneManager.LoadScene("MainMenu");
    }
     
    public void QuitGame()
    {
        Application.Quit();
    }
}
