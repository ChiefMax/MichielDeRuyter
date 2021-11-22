using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Moving left");
            animator.SetBool("isLeftKey", true);
        }
        else 
        {
            animator.SetBool("isLeftKey", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Moving right");
            animator.SetBool("isRightKey", true);
        }

    }
}
