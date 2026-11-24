using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public ColliderDetection cd;
  

    public BoxCollider2D bc2d;

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

    public Vector3 detecetion;

    public float pY;

    public float pX;

    void Start()
    {
        pX = 4;
        bc2d.isTrigger = false;
    }

    void Update()
    {

        

       


    }

    private void FixedUpdate()
    {


        Vector2 playerInput = new Vector2();

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
            playerInput = new Vector2 (0, pY);
            isWalking = false;

        }

        if (cd.isGround)
        {
            pY = 0;
           
        }
        else if (!cd.isGround)
        {
            pY = -3;
            
        }

        {
         
        }



     
        MovementUpdate(playerInput);
  

    }









    private void MovementUpdate(Vector2 playerInput)
    {

       rg2d.linearVelocity = playerInput;
      


    }

    public bool IsWalking()
    {
        
            return isWalking;
        
    
    }
    public bool IsGrounded()
    {
      
        return cd.isGround;
        
    }

    public FacingDirection GetFacingDirection()
    {
      

        return fd;


      


    }

  
    



}
