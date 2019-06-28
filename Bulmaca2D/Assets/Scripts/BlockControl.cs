using UnityEngine;
using System.Collections.Generic;

public class BlockControl : MonoBehaviour
{
    public static int blockCount;
    [SerializeField] private string boxTag = "BOX";

    private static BlockControl _instance;

    public static BlockControl Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("BlockControl");
                go.AddComponent<BlockControl>();
            }

            return _instance;
        }
    }


    [Header("Prefabs")]

    [SerializeField] private GameObject Normal_block_prefab;
    [SerializeField] private GameObject half_block1;
    [SerializeField] private GameObject half_block2;
    [SerializeField] private GameObject half_block3;
    [SerializeField] private GameObject half_block4;
    [SerializeField] private GameObject Randomize_pow_up_prefab;
    [SerializeField] private GameObject Laser_prefab_horizontal;
    [SerializeField] private GameObject Laser_prefab_vertical;
    [SerializeField] private GameObject Laser_prefab_horizontal_and_vertical;


    private string s_tag = "Spawn_pos";
    private int block_width = 7;
    private GameObject[] forGettingTransform = new GameObject[7];
    [SerializeField] private Transform[] spawnPositions = new Transform[7];
    private List<GameObject> blocksArr; 


    void Awake()
    {
        _instance = this;

        forGettingTransform = (GameObject.FindGameObjectsWithTag(s_tag));
        for (int i = 0; i < block_width; i++)
        {
            spawnPositions[i] = forGettingTransform[i].GetComponent<Transform>();
        }
        SpawnBlocks();
    }

    public void SpawnBlocks()
    {

        for (int i = 0; i < block_width; i++)
        {
            float randFloat= Random.Range(0f,90f - GAME_MASTER.Instance.Level * 0.04f);
            if(randFloat < 67f)
            {
                randFloat = Random.Range(0f, 67f);
            }


            if (randFloat >= 0 && randFloat <= 40f)
            {
                Instantiate(Normal_block_prefab, spawnPositions[i].position, Camera.main.transform.rotation);
                blockCount++;
            }
            else if(randFloat > 40f && randFloat <= 45f)
            {
                GameObject block = Instantiate(half_block1,spawnPositions[i].position,Camera.main.transform.rotation);
                blockCount++;
            }
            else if(randFloat > 45 && randFloat <= 50f)
            { 
                GameObject block = Instantiate(half_block2,spawnPositions[i].position,Camera.main.transform.rotation) as GameObject;
                blockCount++;
            }
            else if(randFloat > 50f && randFloat <= 55f)
            {
                GameObject block = Instantiate(half_block3,spawnPositions[i].position,Camera.main.transform.rotation) as GameObject;
                blockCount++;
            }
            else if(randFloat > 55f && randFloat <= 58f)
            {
                GameObject block = Instantiate(half_block4,spawnPositions[i].position,Camera.main.transform.rotation) as GameObject;
                blockCount++;
            }
            else if(randFloat > 58f && randFloat <= 60)
            {
                Instantiate(Randomize_pow_up_prefab,spawnPositions[i].position,Camera.main.transform.rotation);
            }
            else if(randFloat > 60f && randFloat <= 62)
            {
                Instantiate(Laser_prefab_horizontal,spawnPositions[i].position,Camera.main.transform.rotation);
            }
            else if(randFloat > 62f && randFloat <= 65f)
            {
                Instantiate(Laser_prefab_vertical,spawnPositions[i].position,Camera.main.transform.rotation);
            }
            else if(randFloat > 65 && randFloat <= 67f)
            {
                Instantiate(Laser_prefab_horizontal_and_vertical,spawnPositions[i].transform.position,Camera.main.transform.rotation);
            }
            else
            {
                
            }
        }
    }

    public void SlideDownObjects()
    {
        foreach(Slider_scr slidingObj in FindObjectsOfType<Slider_scr>())
        {
            slidingObj.Slide_down();
        }
    }

    


    public void HitBlocksVertical(float yPosition)
    {
        foreach(GameObject block in GameObject.FindGameObjectsWithTag(boxTag))
        {
            if (Mathf.Abs(block.transform.position.y - yPosition) <= 0.4f)
            {
                block.GetComponent<Box_scr>().GetHit();
            }
        }
    }

    public void HitBlocksHorizontal(float xPosition)
    {
        foreach (GameObject block in GameObject.FindGameObjectsWithTag(boxTag))
        {
            if (Mathf.Abs(block.transform.position.x - xPosition) <= 0.4f)
            {
                block.GetComponent<Box_scr>().GetHit();
            }
        }
    }

    public void HitBlocksHorizontalAndVertical(Vector2 pos)
    {
        foreach(GameObject block in GameObject.FindGameObjectsWithTag(boxTag))
        {
            if (Mathf.Abs(block.transform.position.x - pos.x) <= 0.4f || Mathf.Abs(block.transform.position.y - pos.y) <= 0.4f)
            {
                block.GetComponent<Box_scr>().GetHit();
            }
        }
    }

    public void DestroyBlock(GameObject block)
    {
        blocksArr.Remove(block);
        Destroy(block.gameObject);
        return;
    }



}
