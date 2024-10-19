using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Search;

public class Inventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas UIinventory;
    [SerializeField] private TMP_Text prefabText;
    [SerializeField] private GameObject panelParent;

    private List<GameObject> inventoryList = new List<GameObject>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject") && Input.GetMouseButtonDown(0))
        {
            UIinventory.gameObject.SetActive(true);

            TMP_Text instancePrefabText = Instantiate(prefabText);
            instancePrefabText.transform.SetParent(panelParent.transform, false);
            inventoryList.Add(collision.gameObject);


            instancePrefabText.SetText(inventoryList[0].name);

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public bool IsInventoryContaining(string name)
    {
        foreach (GameObject item in inventoryList)
        {
            if(item != null && item.name == name)
            {
                return true;
            }
        }

        return false;
    }
}
