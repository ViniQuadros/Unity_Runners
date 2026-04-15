using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerEffects : MonoBehaviour
{
    public Image blindness;

    private PlayerControl playerControl;

    public void ApplyInvencibility()
    {
        playerControl = GetComponent<PlayerControl>();
        if (playerControl != null)
        {
            playerControl.EnableDeath(false);
        }

        Invoke("PlayerCanDie", 10f);
    }

    private void PlayerCanDie()
    {
        playerControl.EnableDeath(true);
    }

    public void ApplyBlindness()
    {
        blindness.enabled = true;
        StartCoroutine(nameof(RemoveBlindnessAfterTime), 10f);
    }

    private IEnumerator RemoveBlindnessAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        blindness.enabled = false;
    }
}
