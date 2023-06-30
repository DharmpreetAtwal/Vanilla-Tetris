using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] colorList;
    public GameObject[] blockPrefabList;
    private PlayerManager plyManager;
    public GameObject[,] grid= new GameObject[15,12];


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
        GameObject block = plyManager.currentBlock.gameObject;
        if(plyManager.currentBlock.isPlaced)
        {
            for(int i=0;i<block.transform.childCount; i++)
            {
                GameObject tile = block.transform.GetChild(i).gameObject;
                Vector2 point = gameObject.transform.TransformPoint(tile.transform.position);
                int x = (int)point.x / 2;
                int y = (int)point.y / 2;
                grid[y, x] = tile;
            }
            SpawnBlock();
            CheckAlign();
        }
        
    }

    private void CheckAlign()
    {
        for(int row=0; row < grid.GetLength(0); row++)
        {
            int count = 0;
            Color colorCheck;

            if (grid[row, 0] != null)
            {
                colorCheck = grid[row, 0].GetComponent<SpriteRenderer>().color;
            } else {continue;}

            for (int col=0; col<grid.GetLength(1); col++)
            {
                GameObject tile = grid[row, col];
                if (tile != null)
                {
                    Color tileColor = tile.GetComponent<SpriteRenderer>().color;
                    if (tileColor == colorCheck) {count++;}
                } else{ break; }
            }

            if(count == 12){ print("ALIGN " + row); }
        }
    }
}
