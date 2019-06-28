using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Fire_point_scr : Singleton<Fire_point_scr>
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Transform fire_pos;
    public static int current_ball_count;
    [SerializeField]
    private float fire_rate = 0.5f;
    [SerializeField]
    Vector2 spawn_position;
    [SerializeField] private int start_ball_count = 0;
    public static int max_ball_count;//in start have to be 0
    [SerializeField]
    private List<Ball_scr> ball_arr;
    public static bool fire_ended;
    public static bool all_ball_are_down;


    void Start()
    {
        current_ball_count = 0;
        spawn_position = transform.position;
        Drag_deneme.enable_ui = true;
    }

    void Update()
    {
        max_ball_count = GAME_MASTER.Level;
        Instantiete_balls_if_needed();
    }

    public void Set_position(Vector3 pos)
    {
        Debug.Log("Setting new position");
        Debug.Log("new position :" + pos);
        gameObject.transform.position = pos;
    }

    public void StartFire(Vector2 fire_rot)
    {
        StartCoroutine(Firing(fire_rot.normalized));
    }   


    void Instantiete_balls_if_needed()//ball_count will equal to Level
    {
        while(current_ball_count < GAME_MASTER.Level)
        {
            ball_arr.Add(Instantiate(ball,transform.position,transform.rotation).GetComponent<Ball_scr>());
            current_ball_count++;
        }
    }
   
    IEnumerator Firing(Vector2 fire_rot)
    {
        all_ball_are_down = false;//fire start so;
        for(int i = 0;i < current_ball_count;i++)
        {
            Ball_scr ball_scr = ball_arr[i].GetComponent<Ball_scr>();
            ball_scr.Launch(fire_rot);
            yield return new WaitForSeconds(fire_rate);
        }
        fire_ended = true;
    }

}*/
