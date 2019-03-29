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
    public float PlayerSpeed = 5;
    public float JumpHeight = 30;
    private bool _FacingRight = true;

    protected virtual void CheckInputs()
    {
        // ACTIONS
        if (Input.GetKeyDown(this._JumpKey))
        {
            Jump();
        }
        if (Input.GetKeyDown(this._ActivateKey))
        {
            Activate();
        }

        if (Input.GetKey(this._MoveRightKey))
        {
            Flip(1);
            MoveRight();
        }
        else if (Input.GetKey(this._MoveLeftKey))
        {
            Flip(-1);
            MoveLeft();
        }

        // ANIMATIONS
        if ((Input.GetKeyDown(this._MoveLeftKey)) || (Input.GetKeyDown(this._MoveRightKey)))
        {
            this.AnimateSprint();
        }
        if ((Input.GetKeyUp(this._MoveLeftKey)) || (Input.GetKeyUp(this._MoveRightKey)))
        {
            this.AnimateIdle();
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
        //Debug.LogWarning("MUST OVERRIDE MOVE RIGHT");
    }

    protected virtual void MoveLeft()
    {
        //Debug.LogWarning("MUST OVERRIDE MOVE LEFT");
    }

    /* TO PLAY ANIMATIONS */
    protected void Flip(int direction)
    {
        if ((!_FacingRight && direction > 0) || (_FacingRight && direction < 0))
        {
            _FacingRight = !_FacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

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

    // Get the closest <tag> object
    public GameObject FindClosest(string tag)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
