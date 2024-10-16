using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UIElements;

public class Inventory : MonoBehaviour
{
    public Canvas UIinventory;

    public TextMeshPro prefabText;
    public GameObject panelParent;

    private List<GameObject> inventoryList = new List<GameObject>();

    private bool isPlayerPressingLeftClick = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject") && isPlayerPressingLeftClick)
        {
            UIinventory.gameObject.SetActive(true);
            TextMeshPro instancePrefabText = Instantiate(prefabText);
            instancePrefabText.transform.parent = panelParent.transform;
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
