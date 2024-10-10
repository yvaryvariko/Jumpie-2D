using UnityEngine;


public class Controller : MonoBehaviour
{

    private AudioManager AudioManager;
    private Rigidbody2D rb;


    [Header("Jump Values")]
    public Vector2 jumpDir;
    public float jumpForce, jumpForceMultiplier, maxJumpForce, minJumpForce;

    [Header("Ground Check Variables")]
    [SerializeField] private Canvas forceIndicatorCanvas;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private bool isGrounded;

    [Header("Physics Materials 2D")]
    public PhysicsMaterial2D bouncyMat, slipperyMat;


    private void Awake()
    {

    }




    void Start()
    {
        jumpForce = 0;
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        forceIndicatorCanvas.gameObject.SetActive(false);
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
