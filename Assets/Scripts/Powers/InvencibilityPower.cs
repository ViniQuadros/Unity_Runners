using UnityEngine;

public class InvencibilityPower : PowersClass
{
    private PlayerControl playerControl;

    public override void ApplyPower(GameObject player)
    {
        base.ApplyPower(player);
        playerControl = player.GetComponent<PlayerControl>();
        if (playerControl != null)
        {
            playerControl.EnableDeath(false);
        }

        Invoke("PlayerCanDie", 10f);
    }

    private void PlayerCanDie()
    {
        playerControl.EnableDeath(true);
        Destroy(this.gameObject);
    }
}
