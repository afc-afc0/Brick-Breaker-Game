using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_control : MonoBehaviour
{
    public GameObject ball_prefab;
    public int current_ball_count;

    private List<Ball_scr> ball_Arr;
    public int fallen_balls;
    public bool all_ball_fallen;
    public Vector2 ball_start_pos = new Vector3(0f,0f);
    private bool first_ball_hit_ground = false;
    public bool findFirePlace = true;

    private static Ball_control _instance;

    public static Ball_control Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("Ball_control");
                go.AddComponent<Ball_control>();
            }

            return _instance;
        }

        
    }
    
   void Start()
    {
        _instance = this;
        ball_Arr = new List<Ball_scr>();
        Instantiate_balls_if_needed();
    }

    void Update()
    {



        if(findFirePlace == true)
        {
            FindingPlace();
        }

        if (fallen_balls == current_ball_count)
        {
            all_ball_fallen = true;

            GAME_MASTER.Instance.LevelUp();
        }
    }

    public void StartLaunching(Vector2 dir)
    {
        StartCoroutine(Launch_ball(dir.normalized));
        GAME_MASTER.Instance.StagePlaying();
    }



    public IEnumerator Launch_ball(Vector2 rot_vec)
    {
        fallen_balls = 0;
        findFirePlace = false;
        for(int i = 0;i < ball_Arr.Count;i++)
        {
            ball_Arr[i].GetComponent<CircleCollider2D>().enabled = true;
            ball_Arr[i].Launch(rot_vec);
            yield return new WaitForSeconds(0.1f);
        }
        DownBalls.Instance.EnableButton();
    }

    void Instantiate_balls_if_needed()
    {
      
            if (current_ball_count != GAME_MASTER.Instance.Level)//if level ups ball instantitates
            {
                Ball_scr Ball_s = (Instantiate(ball_prefab, SetFirePosition.Instance.LaunchPosition(), Quaternion.identity) as GameObject).GetComponent<Ball_scr>();
                ball_Arr.Add(Ball_s);
                current_ball_count++;
            }
            if(current_ball_count > GAME_MASTER.Instance.Level)
            {
                Destroy(ball_Arr[0]);
            }
    }

    public void MoveToPosition(Transform pos)
    {
        for(int i = 0;i < ball_Arr.Count;i++)
        {
            ball_Arr[i].Move_to(pos);
        }
    }

    public void MoveToPosition(Vector2 pos)
    {
        for(int i = 0;i < ball_Arr.Count;i++)
        {
            if (ball_Arr[i].GetComponent<Ball_scr>().move_to_controller == false && Vector2.Distance(pos,ball_Arr[i].transform.position) != 0)
            {
                ball_Arr[i].GetComponent<CircleCollider2D>().enabled = false;
                ball_Arr[i].Move_to(pos);
            }
        }
    }

    void FindingPlace()
    {
        for(int i = 0;i < ball_Arr.Count;i++)
        {
            ball_Arr[i].SetPosition(SetFirePosition.Instance.LaunchPosition());
        }
    }

    public void OnLevelEnd()
    {
        all_ball_fallen = false;
        fallen_balls = 0;
        Instantiate_balls_if_needed();
        findFirePlace = true;
    }

}
