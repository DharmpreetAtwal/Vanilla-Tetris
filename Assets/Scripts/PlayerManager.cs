using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public BlockBehaviour currentBlock;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: CLEAN UP

        Vector2 change = new Vector2(0, 0);
        Vector2 currentPos = currentBlock.transform.position;

        if (Input.GetKeyDown(KeyCode.A) && !currentBlock.isPlaced)
        {
            change = new Vector2(-2, 0);
        } else if(Input.GetKeyDown(KeyCode.D) && !currentBlock.isPlaced)
        {
            change = new Vector2(2, 0);
        }

        if(gm.checkBounds(currentPos + change))
        {
            currentBlock.transform.position =
            (Vector2)currentBlock.transform.position + change;
        }
    }
}
