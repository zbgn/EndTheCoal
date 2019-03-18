using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public KeyCode _MoveRightKey;
    public KeyCode _MoveLeftKey;
    public KeyCode _JumpKey;
    public KeyCode _ActivateKey;
    public Animator _Animator;

    protected virtual void CheckInputs()
    {
        if (Input.GetKeyDown(this._JumpKey))
        {
            Jump();
        }
        if (Input.GetKeyDown(this._ActivateKey))
        {

        }
        if (Input.GetKey(this._MoveRightKey))
        {
            MoveRight();
        }
        else if (Input.GetKey(this._MoveLeftKey))
        {
            MoveLeft();
        }
        else
        {
            AnimateIdle();
        }
    }

    /* EXECUTE ACTIONS */
    protected virtual void Jump()
    {
        this.AnimateJump();
        StartCoroutine(StopJump());
        Debug.LogWarning("MUST OVERRIDE JUMP");
    }

    protected virtual void Activate()
    {
        Debug.LogWarning("MUST OVERRIDE ACTIVATE");
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(2.0f);
        this.AnimateStopJump();
    }

    protected virtual void MoveRight()
    {
        this.AnimateSprint();
        Debug.LogWarning("MUST OVERRIDE MOVE RIGHT");
    }

    protected virtual void MoveLeft()
    {
        this.AnimateSprint();
        Debug.LogWarning("MUST OVERRIDE MVOE LEFT");
    }

    /* TO PLAY ANIMATIONS */
    protected void AnimateJump()
    {
        this._Animator.SetBool("_IsJumping", true);
    }

    protected void AnimateStopJump()
    {
        this._Animator.SetBool("_IsJumping", false);
    }

    protected void AnimateWalk()
    {
        this._Animator.SetBool("_IsWalking", true);
        this._Animator.SetBool("_IsSprinting", false);
    }

    protected void AnimateSprint()
    {
        this._Animator.SetBool("_IsSprinting", true);
        this._Animator.SetBool("_IsWalking", false);
    }

    protected void AnimateIdle()
    {
        this._Animator.SetBool("_IsSprinting", false);
        this._Animator.SetBool("_IsWalking", false);
    }
}
