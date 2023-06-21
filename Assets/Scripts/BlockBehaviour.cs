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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlaced = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaced)
        {
            Vector2 change = new Vector2(0, Time.deltaTime * -fallSpeed);
            transform.position = (Vector2)transform.position + change;
        }
    }
}
