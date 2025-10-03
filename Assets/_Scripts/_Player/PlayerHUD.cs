using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    public PlayerController player;

    [Header( "UI Elements" )]
    public Slider healthBar;
    public Image dashCooldownImage;

    void Update( ) {
        if ( player != null ) {
            // Update health bar
            healthBar.value = player.GetHealthPercent( );

            // Update dash cooldown (e.g., radial fill)
            dashCooldownImage.fillAmount = player.GetDashCooldownPercent( );
        }
    }
}
