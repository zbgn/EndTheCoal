using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerBase
{
    private Rigidbody2D player;
    protected bool interactable;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInputs();
    }

    protected override void MoveLeft()
    {
        transform.Translate(Vector2.left * PlayerSpeed * Time.deltaTime);
    }

    protected override void MoveRight()
    {
        transform.Translate(Vector2.right * PlayerSpeed * Time.deltaTime);
    }

    public override void Jump(float JJ)
    {
        if (IsGrounded())
        {
            AnimateJump();
            player.AddForce(Vector2.up * JumpHeight * JJ, ForceMode2D.Impulse);
        }
    }

    protected override void Activate()
    {
        if (interactable)
        {
            GameObject interaction = FindClosest("interact");
            interaction.GetComponent<InteractionBase>().Action();
        }
    }

    // Trigers
    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactable |= collision.gameObject.tag == "interact";
        if (IsGrounded())
        {
            AnimateStopJump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        interactable &= collision.gameObject.tag != "interact";
    }
}
