using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] colorList;
    public GameObject[] blockPrefabList;
    private PlayerManager plyManager;

    // Start is called before the first frame update
    void Start()
    {
        plyManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        SpawnBlock();
    }

    private void SpawnBlock()
    {
        plyManager.currentBlock =
            Instantiate(blockPrefabList[0], transform).GetComponent<BlockBehaviour>();
    }

    public bool checkBounds(Vector2 pos)
    {
        if(pos.x >= -8 && pos.x <= 8)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}