using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCue : MonoBehaviour
{
    [SerializeField] private GameObject visualCueLeftClick;
    public GameObject VisualCueLeftClick
    {
        get { return visualCueLeftClick; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            visualCueLeftClick.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            visualCueLeftClick.gameObject.SetActive(false);
        }
    }
}
