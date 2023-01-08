using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 10f;
    
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    
    [SerializeField] private float sprintMultiplier = 1.5f;
    
    private float _currentSpeed;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    private bool _isGrounded;
    
    [Header("Gravity")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 2f;
    [SerializeField] private float terminalVelocity = -20f;

    [Header("Events")]
    [SerializeField] private UnityEvent<float> onMove;
    
    private float _yVelocity;
    private float _terminalVelocityOriginal = 0;

    private void Start()
    {
        if (controller == null)
            throw new NullReferenceException("Player Controller is null!");
        
        if (groundCheck == null)
            throw new NullReferenceException("Ground Check is null!");

        _terminalVelocityOriginal = terminalVelocity;
    }

    private bool IsGrounded()
    => Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

    private float Accelerate() 
        => Mathf.Clamp(_currentSpeed + (acceleration * Time.deltaTime), 0, maxSpeed);

    public void ChangeTerminalVelocity(float vel)
    {
        terminalVelocity = vel;
    }

    public void ResetTerminalVelocity()
    {
        terminalVelocity = _terminalVelocityOriginal;
    }
    
    private void Update()
    {
        Movement();
        Gravity();
    }

    private void Movement()
    {
        // Input
        var xInput = Input.GetAxis("Horizontal");
        var zInput = Input.GetAxis("Vertical");

        var yaw = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        var rawInput = new Vector3(xInput, 0, zInput);
        var isMoving = rawInput.normalized.magnitude > 0;

        var direction = yaw * rawInput;
        
        // Bewegung
        _currentSpeed = isMoving ? Accelerate() : 0;
        
        // Sprinten
        var sprinting = Input.GetButton("Sprint");
        var speed = sprinting ? _currentSpeed * sprintMultiplier : _currentSpeed;

        // Bewegen
        onMove.Invoke(rawInput.normalized.magnitude);
        controller.Move(direction * speed * Time.deltaTime);
    }

    private void Gravity()
    {
        // Physik
        _isGrounded = IsGrounded();

        _yVelocity = _isGrounded ? -2f : _yVelocity + (gravity * Time.deltaTime);

        // Endgeschwindigkeit
        _yVelocity = _yVelocity < terminalVelocity ? terminalVelocity : _yVelocity;
        
        // Springen
        if (Input.GetButton("Jump") && _isGrounded)
        {
            _yVelocity = jumpForce;
        }
        
        // Charakter mit Physik bewegen
        controller.Move(Vector3.up * _yVelocity * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void SetPosition(Vector3 respawnPointPosition)
    {
        // Schalte Physik aus
        controller.enabled = false;
        
        // Setze Position
        transform.position = respawnPointPosition;
        
        // Schalte Physik wieder ein
        controller.enabled = true;
    }
}
