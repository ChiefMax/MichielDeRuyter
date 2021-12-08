using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnim : MonoBehaviour
{
    private Animator animator;
    public GameObject canvas1;
    public GameObject canvas2;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canvas1.activeSelf || canvas2.activeSelf)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Moving left");
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftKey", true);
        }
        else
        {
            animator.SetBool("isLeftKey", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Moving right");
            animator.SetBool("isIdle", false);
            animator.SetBool("isRightKey", true);
        }
        else
        {
            animator.SetBool("isRightKey", false);
        }
    }

    public void BackToIdle() 
    {
        animator.SetBool("isIdle",true);
    }

    public void FreezeMovement()
    {
        animator.SetBool("isLeftKey", false);
        animator.SetBool("isRightKey", false);
    }
}
