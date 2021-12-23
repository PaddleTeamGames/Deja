using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    CharacterController charC;
    InputSystem playerInput;

    Vector2 velocity;
    Vector2 frameVelocity;

    public static bool invertedControls, forwardDisabled, restDisabled, playerHasMoved, alwaysJump;
    public event System.Action Grounded;
    public event System.Action Jumped;

    [Header("Character Movement")]
    public float speed;
    public float friction = 5f;

    [Header("Character Jump")]
    public float baseJump = 7f;
    private static float jumpStrength;
    public float gravity;

    [Header("Mouse Look Variables")]
    public Camera firstPersonCamera;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public bool isGrounded;
    bool isGroundedNow;
    Vector3 fallVelocity;
    public LayerMask collisionMask;

    float lastJumpPress = -1;
    float jumpPressDuration = .1f;

    void Awake()
    {
        charC = GetComponent<CharacterController>();
        invertedControls = false;
        forwardDisabled = false;
        restDisabled = false;
        alwaysJump = false;
        jumpStrength = baseJump;

        playerInput = new InputSystem();
        playerInput.Menu.Disable();
        playerInput.Player.Enable();
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;

        playerHasMoved = false;
    }

    void Update()
    {
        MouseLook();
        playerInput.Player.Jump.performed += JumpInput;

        if (alwaysJump)
            lastJumpPress = Time.time;

        Movement();
    }

    private void Movement()
    {

        Vector3 playerVelocity = new Vector3(GetInput().x * speed, 0, GetInput().y * speed);

        playerVelocity = CalculateFriction(playerVelocity);
        charC.Move(transform.rotation * (playerVelocity * Time.deltaTime));

        GroundCheck();
    }

    #region Mouse Look
    void MouseLook()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = playerInput.Player.Look.ReadValue<Vector2>();
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
    
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
    
        // Rotate camera up-down and controller left-right from velocity.
        firstPersonCamera.transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        firstPersonCamera.ResetProjectionMatrix();
        transform.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
    #endregion

    #region Jump
    public void JumpInput(InputAction.CallbackContext context)
    {
        lastJumpPress = Time.time;
    }

    private Vector3 GetJumpVelocity(float yVelocity)
    {
        Vector3 jumpVelocity = Vector3.zero;

        if (Time.time < lastJumpPress + jumpPressDuration && yVelocity < jumpStrength && isGrounded)
        {
            Stats.timesJumped++;
            lastJumpPress = -1f;

            jumpVelocity = new Vector3(0f, Mathf.Sqrt(jumpStrength * -2f * gravity), 0f);
            Jumped?.Invoke();

            isGroundedNow = false;
        }

        return jumpVelocity;
    }

    public void JumpBoosted(float value)
    {
        jumpStrength = baseJump * value;
    }
    #endregion

    #region GroundCheck
    private void GroundCheck()
    {
        fallVelocity.y += gravity * Time.deltaTime;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, collisionMask, QueryTriggerInteraction.Ignore);

        if (isGrounded && fallVelocity.y < 0)
        {
            fallVelocity.y = -2f;
            if (!isGroundedNow)
            {
                Grounded?.Invoke();
                isGroundedNow = true;
            }
        }

        fallVelocity += GetJumpVelocity(fallVelocity.y);

        charC.Move(fallVelocity * Time.deltaTime);
    }
    #endregion

    #region Movement Calculations
    Vector2 GetInput()
    {
        Vector2 input = playerInput.Player.Move.ReadValue<Vector2>();

        if (invertedControls)
            input *= -1;

        if (forwardDisabled)
            if (input.y > 0) input.y = 0;

        if (restDisabled)
        {
            if (input.x != 0) input.x = 0;
            if (input.y < 0) input.y = 0;
        }

        if (input != Vector2.zero) playerHasMoved = true;

        return input;
    }

    Vector3 CalculateFriction(Vector3 currentVelocity)
    {
        float speed = currentVelocity.magnitude;

        if (!isGrounded || speed == 0f)
            return currentVelocity;

        float drop = speed * friction * Time.deltaTime;
        return currentVelocity * (Mathf.Max(speed - drop, 0f) / speed);
    }

    public static void LockPlayerMovement()
    {
        forwardDisabled = true;
        restDisabled = true;
    }
    #endregion
}