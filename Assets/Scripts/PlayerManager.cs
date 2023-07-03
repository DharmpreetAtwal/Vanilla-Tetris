using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public BlockBehaviour currentBlock;

    void Update()
    {
        Vector2 change = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.A) && !currentBlock.isPlaced)
        {
            change = new Vector2(-2, 0);
        } else if (Input.GetKeyDown(KeyCode.D) && !currentBlock.isPlaced)
        {
            change = new Vector2(2, 0);
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            currentBlock.gameObject.transform.Rotate(Vector3.back, 90);
        }

        currentBlock.transform.position = (Vector2)currentBlock.transform.position + change;

    }
}
