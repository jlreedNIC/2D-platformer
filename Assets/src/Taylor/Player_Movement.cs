using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //these will be our base player movement speed and jump height. 
    //serialized field lets us have private variables vieded and edited in Unity editor 
    [SerializeField] private float _playerMovementSpeed = 5.0f; 
    [SerializeField] private float _playerJumpHeight = 5.0f; 
    [SerializeField] private Transform _groundChecker; 
    [SerializeField] private float _groundCheckerRadius; 
    [SerializeField] private LayerMask _groundLayer;  
    [SerializeField] private bool _isTouchingGround;  

    // for animation
    public Animator animator;


    //player rigidbody
    [SerializeField] private Rigidbody2D _playerRB; 

    // Start is called before the first frame update
    private void Start()
    {
        //grab the RigidBody2D component for movement
        _playerRB = GetComponent<Rigidbody2D>(); 

        //null game object check
        if(_playerRB == null)
        {
            Debug.Log("Player is Missing RigidBody2D");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //get input and move player
        MovePlayer(); 

        

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            // set jump animation to start
            animator.SetBool("isJumping", true);
            Jump();
        }
        
        // set jump animation to stop
        if(_playerRB.velocity.y == 0 && IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
    }

    //using unity's expression method, we can make a clean one line function.
    // private void Jump() => _playerRB.velocity = new Vector2(0 , _playerJumpHeight); 

    //However to follow coding standards, we use brackets even for one liners
    //function to make player jump
    private void Jump()
    {
        _playerRB.velocity = new Vector2(_playerRB.velocity.x, _playerJumpHeight); 
    }

    //function to check if the player is on level terrain
    private bool IsGrounded()
    {
        return _isTouchingGround = Physics2D.OverlapCircle(_groundChecker.position,_groundCheckerRadius, _groundLayer); 
    }

    //horizontal player movement function 
    private void MovePlayer()
    {
        //using the unity input manager
        //grab the horizontal axis input. 
        //this will be the left and right arrows on a keyboard
        var horizontalMovementInput = Input.GetAxisRaw("Horizontal"); 

        //move the player
        _playerRB.velocity = new Vector2(horizontalMovementInput * _playerMovementSpeed, _playerRB.velocity.y); 

        // animation
        animator.SetFloat("speed", Mathf.Abs(_playerRB.velocity.x));
    }
}
