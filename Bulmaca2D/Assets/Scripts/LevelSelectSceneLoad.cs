using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectSceneLoad : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
