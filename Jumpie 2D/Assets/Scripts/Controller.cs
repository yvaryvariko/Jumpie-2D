using UnityEngine;


public class Controller : MonoBehaviour
{

    private AudioManager AudioManager;
    private Rigidbody2D rb;


    [Header("Jump Values")]
    [SerializeField] public Vector2 jumpDir;
    [SerializeField] public float jumpForce, jumpForceMultiplier, maxJumpForce, minJumpForce;

    [Header("Ground Check Variables")]
    [SerializeField] private Canvas forceIndicatorCanvas;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private bool isGrounded;

    [Header("Physics Materials 2D")]
    [SerializeField] private PhysicsMaterial2D bouncyMat, slipperyMat;


    void Start()
    {
        jumpForce = 0;
        rb = GetComponent<Rigidbody2D>();       
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        AudioManager = FindObjectOfType<AudioManager>();

    }



    private void Update()
    {

        HandleInput();   

    }



    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
        

        if (isGrounded)
        {
            rb.sharedMaterial = slipperyMat;
        }
        else
        {
            rb.sharedMaterial = bouncyMat;
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }



    void HandleInput()
    {

        if (Input.GetMouseButton(0) && isGrounded)
        {
            forceIndicatorCanvas.gameObject.SetActive(true);

            Vector2 mousePositionOnScreen = Input.mousePosition; //get mouse position on screen

            
            if (mousePositionOnScreen.x < Screen.width / 2f)  //check on which side mouse was pressed and change Jump Direction Accordingly
            {
                jumpDir.x = -Mathf.Abs(jumpDir.x);
      
            }
            else
            {
                jumpDir.x = Mathf.Abs(jumpDir.x);
    
            }

            //jumpDir.Normalize();

            jumpForce = Mathf.Clamp(jumpForce + jumpForceMultiplier * Time.deltaTime, minJumpForce, maxJumpForce);  //calculate Jumpforce


            if (jumpForce >= maxJumpForce)
            {
                Jump();
            }
        }


        //When Finger Is Released
        if (Input.GetMouseButtonUp(0) && isGrounded)
        {

            Jump();
        }


    }

    private void Jump()
    {
        
        AudioManager.Play("Jump");
        rb.velocity = jumpDir * jumpForce;
        jumpForce = 0f;
        forceIndicatorCanvas.gameObject.SetActive(false);

    }

}
