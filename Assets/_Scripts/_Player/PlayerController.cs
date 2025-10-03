using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header( "Health" )]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header( "Dash" )]
    public float dashCooldown = 3f;
    private float dashCooldownTimer;

    public bool CanDash => dashCooldownTimer <= 0f;

    void Start( ) {
        currentHealth = maxHealth;
        dashCooldownTimer = 0f;
    }

    void Update( ) {
        // Dash cooldown timer
        if ( dashCooldownTimer > 0f )
            dashCooldownTimer -= Time.deltaTime;
    }

    public void Dash( ) {
        if ( CanDash ) {
            // Perform dash logic here...
            dashCooldownTimer = dashCooldown;
        }
    }

    public float GetDashCooldownRemaining( ) => Mathf.Clamp( dashCooldownTimer , 0 , dashCooldown );
    public float GetDashCooldownPercent( ) => 1 - ( GetDashCooldownRemaining( ) / dashCooldown );
    public float GetHealthPercent( ) => currentHealth / maxHealth;

    // Example damage function
    public void TakeDamage( float amount ) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp( currentHealth , 0f , maxHealth );
    }
}
