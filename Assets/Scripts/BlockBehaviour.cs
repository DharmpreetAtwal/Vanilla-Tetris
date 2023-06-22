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
        isPlaced = false;
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
        InvokeRepeating("MoveDown", 0, 0.5f);
    }

    public void StopMove()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bottom") || collision.CompareTag("Block"))
        {
            isPlaced = true;
            StopMove();
        }
        else if (collision.CompareTag("LeftBound"))
        {
            //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            //transform.position = (Vector2)transform.position + new Vector2(2, 0);
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

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
