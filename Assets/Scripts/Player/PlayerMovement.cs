using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerspeed = 3f;
    [SerializeField] private float sprintMultiplier = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (DialogueController.Instance != null && DialogueController.Instance.isDialogOn)
        {
            return;
        }

        float move = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            move *= sprintMultiplier; 
        }

        rb.velocity = new Vector2(move * playerspeed, rb.velocity.y);

        if (move == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
