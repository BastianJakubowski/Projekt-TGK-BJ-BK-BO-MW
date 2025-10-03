using UnityEngine;

[RequireComponent( typeof( Rigidbody ) )]
public class SimplePlayerMovement : MonoBehaviour {
    [Header( "Movement Settings" )]
    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 movement;

    [Header( "Dash Settings" )]
    public int maxDashCharges;
    private int currentDashCharges;
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;

    private bool isDashing = false;
    private float dashTimer;
    private float cooldownTimer;

    private Vector3 dashDirection;

    void Start( ) {
        rb = GetComponent<Rigidbody>( );
        rb.freezeRotation = true;
        currentDashCharges = maxDashCharges;
    }

    void Update( ) {
        // Handle dash input
        if ( Input.GetKeyDown( KeyCode.Q ) && currentDashCharges > 0 && !isDashing ) {
            StartDash( );
        }

        // Recharge dash charges over time
        if ( currentDashCharges < maxDashCharges ) {
            cooldownTimer += Time.deltaTime;
            if ( cooldownTimer >= dashCooldown ) {
                currentDashCharges++;
                cooldownTimer = 0f;
            }
        }

        // Dash duration logic
        if ( isDashing ) {
            dashTimer += Time.deltaTime;
            if ( dashTimer >= dashDuration ) {
                isDashing = false;
                dashTimer = 0f;
            }
        }
    }

    void FixedUpdate( ) {
        if ( !isDashing ) {
            float x = Input.GetAxis( "Horizontal" );
            float z = Input.GetAxis( "Vertical" );
            movement = transform.right * x + transform.forward * z;

            rb.MovePosition( rb.position + movement * moveSpeed * Time.fixedDeltaTime );
        } else {
            // Apply dash movement
            rb.MovePosition( rb.position + dashDirection * dashForce * Time.fixedDeltaTime );
        }
    }

    void StartDash( ) {
        dashDirection = movement.normalized;
        if ( dashDirection == Vector3.zero )
            dashDirection = transform.forward; // Dash forward if no movement input

        isDashing = true;
        currentDashCharges--;
        cooldownTimer = 0f;
    }

    // Exposed for UI
    public float GetDashCooldownPercent( ) {
        if ( currentDashCharges >= maxDashCharges )
            return 1f;

        return Mathf.Clamp01( cooldownTimer / dashCooldown );
    }

    public int GetDashCharges( ) => currentDashCharges;
    public int GetMaxDashCharges( ) => maxDashCharges;
}
