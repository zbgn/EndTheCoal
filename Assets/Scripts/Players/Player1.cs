using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{

    private Rigidbody2D player;
    protected bool grounded = true;
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
        transform.Translate(Vector2.left * PlayerSpeed *Time.deltaTime);
    }

    protected override void MoveRight()
    {
        transform.Translate(Vector2.right * PlayerSpeed * Time.deltaTime);
    }

    protected override void Jump()
    {
        if (grounded)
        {
            AnimateJump();
            player.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
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
        grounded |= collision.gameObject.tag == "floor";
        interactable |= collision.gameObject.tag == "interact";
        if (grounded)
        {
            AnimateStopJump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded &= collision.gameObject.tag != "floor";
        interactable &= collision.gameObject.tag != "interact";
    }
}
