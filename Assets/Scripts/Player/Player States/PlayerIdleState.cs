using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerIdleState : PlayerBaseState
{
    // Input Variables
    private Vector2 playerInput;
    private float dirX;
    private float dirY;

    public override void EnterState(PlayerStateManager player)
    {
        player.Animator.SetBool("IsMoving", false);
        GetPlayerInput();
        ChangeCurrentAnimation(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (playerInput.magnitude == 0f)
        {
            GetPlayerInput();
            ChangeCurrentAnimation(player);
        }
        else
        {
            player.SwitchState(player.MovingState);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    private void GetPlayerInput()
    {
        dirY = Input.GetAxisRaw("Vertical");
        dirX = Input.GetAxisRaw("Horizontal");
        playerInput = new Vector2(dirX, dirY).normalized;
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
