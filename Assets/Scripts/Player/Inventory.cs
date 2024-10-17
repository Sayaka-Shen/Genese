using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UIElements;

public class Inventory : MonoBehaviour
{
    public Canvas UIinventory;

    public TMP_Text prefabText;
    public GameObject panelParent;

    private List<GameObject> inventoryList = new List<GameObject>();

    private bool isPlayerPressingLeftClick = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject") && isPlayerPressingLeftClick)
        {
            UIinventory.gameObject.SetActive(true);
            TMP_Text instancePrefabText = Instantiate(prefabText);
            instancePrefabText.transform.SetParent(panelParent.transform, false);
            inventoryList.Add(collision.gameObject);

            Destroy(collision.gameObject);
        }
        else
        {
            Resetpopup();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlayerPressingLeftClick = true;
            Debug.Log("L'objet à été récupérer");
        }
    }
    private void Resetpopup()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isPlayerPressingLeftClick = false;
            Debug.Log("L'objet est au sol");
        }
    }
}
