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


    // TODO: Fix movement system. First Box Collider should be moved through offset, if no collision, them move image

    // Update is called once per frame
    void Update()
    {
        Vector2 change = new Vector2(0, 0);
        Vector2 currentPos = currentBlock.transform.position;

        if (Input.GetKeyDown(KeyCode.A) && !currentBlock.isPlaced)
        {
            change = new Vector2(-2, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !currentBlock.isPlaced)
        {
            change = new Vector2(2, 0);

        // TODO: Rotation should change position of child blocks
        } else if(Input.GetKeyDown(KeyCode.E))
        {
            currentBlock.gameObject.transform.Rotate(Vector3.back, 90);
        }

        if (gm.checkBounds(currentPos + change))
        {
            currentBlock.transform.position =
            (Vector2)currentBlock.transform.position + change;
        }
    }
}
