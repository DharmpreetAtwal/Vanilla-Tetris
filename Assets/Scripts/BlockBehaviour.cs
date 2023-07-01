using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public float fallSpeed;
    public bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(12, 36);
        //EnableTiles(false);
        BeginMove();
    }

    public void changeColor(Color col)
    {
        SpriteRenderer[] spriteList = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < spriteList.Length; i++)
        {
            spriteList[i].color = col;
        }
    }

    public void BeginMove()
    {
        InvokeRepeating("MoveDown", 0, 0.4f);
        isPlaced = false;
    }

    private void MoveDown()
    {
        Vector2 change = new Vector2(0, -1);
        transform.position = (Vector2)transform.position + change;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Bottom") && !isPlaced)
        if (collision.CompareTag("Bottom"))
        {
            transform.position = (Vector2)transform.position + new Vector2(0, 1);
            StopMove();
        }
        else if (collision.CompareTag("Block") && !isPlaced)
            //|| collision.CompareTag("Tile"))
        {
            transform.position = (Vector2)transform.position + new Vector2(0, 1);
            //gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            StopMove();
        }
        else if (collision.CompareTag("LeftBound"))
        {
            transform.position = (Vector2)transform.position + new Vector2(2, 0);
        }
        else if (collision.CompareTag("RightBound"))
        {
            transform.position = (Vector2)transform.position + new Vector2(-2, 0);
        }
    }

    public void StopMove()
    {
        CancelInvoke();
        isPlaced = true;
        //EnableTiles(true);
    }

    //private void EnableTiles(bool value)
    //{
    //    BoxCollider2D[] colliders =
    //        gameObject.GetComponentsInChildren<BoxCollider2D>();
    //    //TileBehaviour[] scripts =
    //    //    gameObject.GetComponentsInChildren<TileBehaviour>();

    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        colliders[i].enabled = value;
    //        //scripts[i].enabled = value;
    //    }
    //}

}
