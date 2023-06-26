using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] colorList;
    public GameObject[] blockPrefabList;
    private PlayerManager plyManager;
    public GameObject[,] grid= new GameObject[14,11];

    // Start is called before the first frame update
    void Start()
    {
        plyManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        SpawnBlock();
    }

    private void SpawnBlock()
    {
        int rndIntBlock = Random.Range(0, blockPrefabList.Length);
        plyManager.currentBlock =
            Instantiate(blockPrefabList[rndIntBlock],
            transform).GetComponent<BlockBehaviour>();

        Color rndColor = colorList[Random.Range(0, colorList.Length)];
        plyManager.currentBlock.changeColor(rndColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(plyManager.currentBlock.isPlaced)
        {
            SpawnBlock();
        }
        
    }
}
