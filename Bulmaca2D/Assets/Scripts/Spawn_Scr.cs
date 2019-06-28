using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Scr : Singleton<Spawn_Scr>
{

    [Header("Prefabs")]

    [SerializeField] private GameObject Normal_block_prefab;
    [SerializeField] private GameObject half_block1;
    [SerializeField] private GameObject half_block2;
    [SerializeField] private GameObject half_block3;
    [SerializeField] private GameObject half_block4;
    [SerializeField] private GameObject Randomize_pow_up_prefab;
    [SerializeField] private GameObject Add_ball_prefab;
    [SerializeField] private GameObject Laser_prefab_horizontal;
    [SerializeField] private GameObject Laser_prefab_vertical;


    private string s_tag = "Spawn_pos";
    private int block_width = 7;
    private GameObject[] for_getting_transform = new GameObject[7];
    [SerializeField]private Transform[] spawn_positions = new Transform[7];

    void Awake()
    {
        for_getting_transform = (GameObject.FindGameObjectsWithTag(s_tag));
        for(int i = 0;i < block_width;i++)
        {
            spawn_positions[i] = for_getting_transform[i].GetComponent<Transform>();
        }
        SpawnBlocks();
    }
   
    void SpawnBlocks()
    {

        for (int i = 0;i < block_width; i++)
        {
            if(Random.Range(0f,100f) > 40f)
            {
              Instantiate(Normal_block_prefab,spawn_positions[i].position,Camera.main.transform.rotation);
            }
        }
    }

}
