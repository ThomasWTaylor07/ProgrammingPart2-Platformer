using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 playerInput;

    public Rigidbody2D rg2d;
    public enum FacingDirection
    {
        left, right
    }

    FacingDirection fd;


    public Animator anim;

    public bool isWalking;

    public bool onGround;

    public bool direction;

    void Start()
    {
        onGround = true; 
    }

    void Update()
    {
       
      
        playerInput = new Vector2();

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput += new Vector2(-1, 0);
            isWalking = true;
            direction = true;

        }

       else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput += new Vector2(1, 0);
            isWalking = true;
            direction = false;

        }

        else if(!Keyboard.current.leftArrowKey.isPressed && !Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput += new Vector2(0, 0);
            isWalking = false;

        }

        

        Debug.Log(playerInput);

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        rg2d.AddForce(playerInput);


        
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
       
        if (direction == true)
        {
            fd = FacingDirection.left;
        }

        if (direction == false)
        {
            fd = FacingDirection.right;
        }

        return fd;
      


    }


}
