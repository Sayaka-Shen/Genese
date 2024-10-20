using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isPlayerPressingE;
    public bool IsPlayerPressingE { get { return isPlayerPressingE; } }

    private bool isPlayerPressingI;
    public bool IsPlayerPressingI { get { return isPlayerPressingI; } }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isPlayerPressingE = true;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            isPlayerPressingI = true;
        }
    }

    public void ResetInteractionStateE()
    {
        isPlayerPressingE = false;
    }

    public void ResetInteractionStateI()
    {
        isPlayerPressingI = false;
    }
}
