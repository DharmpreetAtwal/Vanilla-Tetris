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
            Vector2 center = currentBlock.gameObject.transform.position
                + currentBlock.gameObject.transform.TransformDirection(new Vector3(2, 0, 0));
            currentBlock.gameObject.transform.RotateAround(center, Vector3.back, 90);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            change = new Vector2(0, -1);
        }

        currentBlock.transform.position = (Vector2)currentBlock.transform.position + change;
    }
}
