using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_spawner : Singleton<Block_spawner>
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

    [Header("Spawn_pos")]
    [SerializeField]private List<Transform> Spawn_pos; 

    void Start()
    {
        InvokeRepeating("Spawn_blocks",3f,30f);
    }

    public void Spawn_blocks()
    {
        Debug.Log("spawning blocks");
        for(int i = 0;i < Spawn_pos.Count;i++)
        {
            if(Random.Range(0f,100f) > 50f)
            {
                Instantiate(Normal_block_prefab,Spawn_pos[i]);
            }
        }
    }

}
