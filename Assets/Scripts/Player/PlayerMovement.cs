using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerspeed = 3f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (DialogueController.Instance != null && DialogueController.Instance.IsDialogOn)
        {
            return;
        }

        float move = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            move *= sprintMultiplier; 
        }

        rb.velocity = new Vector2(move * playerspeed, rb.velocity.y);

        if(move != 0 && playerAnimator != null)
        {
            playerAnimator.SetBool("IsPlayerWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsPlayerWalking", false);
        }

        if (move == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(move < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            playerSpriteRenderer.flipX = false;
        }
    }
}
