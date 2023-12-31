using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] colorList;
    public GameObject[] blockPrefabList;
    private PlayerManager plyManager;
    public GameObject[,] grid= new GameObject[15,12];
    public BlockBehaviour nextBlock;

    // Start is called before the first frame update
    void Start()
    {
        plyManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        plyManager.currentBlock = SpawnBlock();
        nextBlock = SpawnNextBlock();
    }

    private BlockBehaviour SpawnBlock()
    {
        int rndIntBlock = Random.Range(0, blockPrefabList.Length);
        BlockBehaviour block =
            Instantiate(blockPrefabList[rndIntBlock],
            transform).GetComponent<BlockBehaviour>();

        Color rndColor = colorList[Random.Range(0, colorList.Length)];
        block.changeColor(rndColor);

        return block;
    }

    private BlockBehaviour SpawnNextBlock()
    {
        BlockBehaviour block = SpawnBlock();
        block.gameObject.transform.position = new Vector2(-8.5f, 25);
        block.enabled = false;

        return block;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject block = plyManager.currentBlock.gameObject;
        if(plyManager.currentBlock.isPlaced)
        {
            foreach(Transform tileChild in block.transform)
            {
                Vector2 point = transform.TransformPoint(tileChild.position);
                int x = Mathf.RoundToInt(point.x / 2);
                int y = Mathf.RoundToInt(point.y / 2);
                grid[y, x] = tileChild.gameObject;
            }
            plyManager.currentBlock = nextBlock;
            plyManager.currentBlock.enabled = true;
            nextBlock = SpawnNextBlock();
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
                    if (tileColor == colorCheck) {count++;} else { break;  }
                } else{ break; }
            }

            if(count == 12){ DeleteRow(row); MoveAboveTilesDown(row); }
        }
    }

    private void DeleteRow(int row)
    {
        for(int col=0; col<grid.GetLength(1); col++){Destroy(grid[row, col]);}
    }

    private void MoveAboveTilesDown(int deletedRow)
    {
        for (int row=deletedRow; row<grid.GetLength(0) - 1; row++)
        {
            for(int col=0; col<grid.GetLength(1); col++)
            {
                if(grid[row + 1, col] != null)
                {
                    grid[row + 1, col].transform.position += new Vector3(0, -2, 0);
                    grid[row, col] = grid[row + 1, col];
                    grid[row + 1, col] = null;
                }
            }
        }
    }
}
