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
        Debug.Log("I am Idle");
        GetPlayerInput();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (playerInput.magnitude == 0f)
        {
            GetPlayerInput();
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
}
