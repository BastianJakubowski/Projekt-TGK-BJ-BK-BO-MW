using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    public PlayerController player;
    public SimplePlayerMovement Movement_and_dash;

    [Header( "UI Elements" )]
    public Slider healthBar;
    public Image dashCooldownImage;

    void Update( ) {
        if ( player != null ) {
            // Update health bar
            healthBar.value = player.GetHealthPercent( );

            // Update dash cooldown (e.g., radial fill)
            dashCooldownImage.fillAmount = Movement_and_dash
                .GetDashCooldownPercent( );
        }
    }
}
