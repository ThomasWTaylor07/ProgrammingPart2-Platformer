using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //public ColliderDetection cd;


    public BoxCollider2D bc2d;

    public Rigidbody2D rg2d;
    public enum FacingDirection
    {
        left, right
    }

    FacingDirection fd;


    public Animator anim;

    public Vector2 playerInput;

    public bool isWalking;

    public float apexHeight = 3f;

    public float apexTime = 0.5f;

    public bool onGround;

    public bool direction;

    public Vector3 detecetion;

    public float pY;

    public float pX;

    public float gravity;

    public float jVelocity;

    public float groundCheckoff = 0.6f;
    public Vector2 gcSize = new(0.5f, 0.1f);
    public LayerMask gcM;

    private bool isJumping;

    public float termVel;

    void Start()
    {
        rg2d.gravityScale = 0;
        pX = 4;
        bc2d.isTrigger = false;

        gravity = apexHeight * -2f / Mathf.Pow(apexTime, 2);
        jVelocity = 2 * apexHeight / apexTime;
        termVel = -2 * jVelocity;
    }

    void Update()
    {
        groundCheck();

        

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput = new Vector2(-pX, pY);
            isWalking = true;
            fd = FacingDirection.left;

        }

        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput = new Vector2(pX, pY);
            isWalking = true;
            fd = FacingDirection.right;

        }

        else if (!Keyboard.current.leftArrowKey.isPressed && !Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput = new Vector2(0, pY);
            isWalking = false;

        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && onGround)
        {
            isJumping = true;
        }

        Debug.Log(onGround);
        if (isJumping == false)
        {
            Debug.Log("Not jumping");
        }
        Debug.Log(isJumping);
    }

    private void FixedUpdate()
    {
        if (!onGround)
        {
            playerInput.y += gravity * Time.deltaTime;
        }

        else
        {
            playerInput.y = 0;
        }

        if (isJumping)
        {
            isJumping = false;
            playerInput.y = jVelocity;
        }

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        rg2d.linearVelocity = playerInput;
        pY = rg2d.linearVelocity.y;
    }

    public bool IsWalking()
    {

        return isWalking;


    }
    public bool IsGrounded()
    {

        return onGround;

    }

    public FacingDirection GetFacingDirection()
    {
        return fd;
    }

    private void groundCheck()
    {
        onGround = Physics2D.OverlapBox(transform.position + Vector3.down * groundCheckoff, gcSize, 0, gcM);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down * groundCheckoff, gcSize);
    }



}
