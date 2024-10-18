using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Canvas playMenu;

    private void Update()
    {
        if(playMenu.gameObject.activeSelf)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(true);
        }
    }
}
