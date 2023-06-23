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
        transform.position = new Vector2(0, 12);
        BeginMove();
    }

    private void MoveDown()
    {
        Vector2 change = new Vector2(0, -1);
        transform.position = (Vector2)transform.position + change;
    }

    public void BeginMove()
    {
        InvokeRepeating("MoveDown", 0, 0.2f);
        isPlaced = false;
    }

    public void StopMove()
    {
        CancelInvoke();
        isPlaced = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bottom"))
        {
            StopMove();
        } else if(collision.CompareTag("Block") && !isPlaced)
        {
            StopMove();
            transform.position = (Vector2)transform.position + new Vector2(0, 1);
        } else if (collision.CompareTag("LeftBound"))
        {
            transform.position = (Vector2)transform.position + new Vector2(2, 0);
        } else if(collision.CompareTag("RightBound"))
        {
            transform.position = (Vector2)transform.position + new Vector2(-2, 0);
        } 
    }

    public void changeColor(Color col)
    {
        SpriteRenderer[] spriteList = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i=0; i< spriteList.Length; i++)
        {
            spriteList[i].color = col;
        }
    }

}
