using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> inventoryList = new List<GameObject>();

    private bool isPlayerPressingLeftClick = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject") && isPlayerPressingLeftClick)
        {
            inventoryList.Add(collision.gameObject);

            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlayerPressingLeftClick = true;
            Debug.Log("L'objet à été récupérer");
        }
        else
        {
            isPlayerPressingLeftClick = false;
        }
    }

}
