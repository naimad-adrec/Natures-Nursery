using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am Idle");
        player.RigidBody.velocity = Vector2.zero;
        player.Animator.SetBool("IsMoving", false);
        ChangeCurrentAnimation(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.PlayerInput.magnitude == 0f && player.IsInteracting == false)
        {
            GetPlayerItemChangeInput(player);
            ChangeCurrentAnimation(player);
        }
        else if (player.PlayerInput.magnitude != 0f && player.IsInteracting == false)
        {
            player.SwitchState(player.MovingState);
        }
        else
        {
            player.SwitchState(player.InteractingState);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    private void GetPlayerItemChangeInput(PlayerStateManager player)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.CurrentItemIdx == player.CurrentItems.Count - 1)
            {
                player.CurrentItemIdx = 0;
                player.CurrentItem = player.CurrentItems[player.CurrentItemIdx];
            }
            else
            {
                player.CurrentItem = player.CurrentItems[player.CurrentItemIdx + 1];
                player.CurrentItemIdx++;
            }
        }
    }

    private void ChangeCurrentAnimation(PlayerStateManager player)
    {
        player.Animator.SetFloat("X", player.LastDirX);
        player.Animator.SetFloat("Y", player.LastDirY);

        if (player.LastDirX != -1f)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}