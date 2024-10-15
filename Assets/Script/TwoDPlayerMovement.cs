using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgBody;
    private Animator animator;

    [SerializeField] public float horizontalMoveSpeed = 1.5f;
    [SerializeField] public float verticalMoveSpeed = 1.5f;
    private bool isFalling = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if ((int)horizontalInput!=0 || (int)verticalInput!=0)
        {
            Debug.Log("The player is moved:"+ horizontalInput+"|"+verticalInput);
            
        }

        if (horizontalInput > 0.01)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        if (verticalInput > 0)
        {
            isJumping = true;
        }
        else if(isJumping)
        {
            isFalling = true;
            isJumping = false;
        }
        animator.SetBool("IsJumping", isJumping);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput * horizontalMoveSpeed));

        Debug.Log(isFalling);


        //movement

        //if (isFalling)
        //{
        //    rgBody.velocity = new Vector2(horizontalInput * horizontalMoveSpeed,
        //        -5);
        //}
        //else
        //{
        //    rgBody.velocity = new Vector2(horizontalInput * horizontalMoveSpeed,
        //    verticalInput * verticalMoveSpeed);
        //}

        rgBody.velocity = new Vector2(horizontalInput * horizontalMoveSpeed,
            verticalInput * verticalMoveSpeed);



    }
}
