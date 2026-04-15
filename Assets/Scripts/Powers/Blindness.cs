using UnityEngine;

public class Blindness : PowersClass
{
    public override void ApplyPower(GameObject player, GameObject otherPlayer)
    {
        base.ApplyPower(player, otherPlayer);

        otherPlayer.GetComponent<PowerEffects>().ApplyBlindness();
    }
}
