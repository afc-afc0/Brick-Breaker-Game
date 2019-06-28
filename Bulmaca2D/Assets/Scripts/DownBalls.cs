using UnityEngine;

class DownBalls : MonoBehaviour
{
    public static DownBalls Instance;

    [SerializeField] private Canvas DownBallsCanvas;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void DisableButton()
    {
        gameObject.SetActive(false);
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);
    }

    public void MoveBallsToContoller()
    {
        Ball_control.Instance.MoveToPosition(SetFirePosition.Instance.LaunchPosition2d());
        gameObject.SetActive(false);
    }

}
