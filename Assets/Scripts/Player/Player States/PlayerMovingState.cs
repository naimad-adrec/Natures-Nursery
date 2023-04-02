using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovingState : PlayerBaseState
{
    // Movement Variables
    [SerializeField] private float moveSpeed = 200f;
    private Vector3 moveDir;

    // Input Variables
    private Vector2 playerInput;
    private float dirX;
    private float dirY;

    public override void EnterState(PlayerStateManager player)
    {
        player.Animator.SetBool("IsMoving", true);
        GetPlayerMovementInput();
        ChangeCurrentAnimation(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (playerInput.magnitude != 0f && player.IsInteracting == false)
        {
            player.LastDirX = dirX;
            player.LastDirY = dirY;
            GetPlayerMovementInput();
            GetPlayerItemChangeInput(player);
            ApplyPlayerMovement(player);
            ChangeCurrentAnimation(player);
        }
        else if (playerInput.magnitude == 0f && player.IsInteracting == false)
        {
            player.SwitchState(player.IdleState);
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
            player.CurrentItem = player.CurrentItems[player.CurrentItemIdx + 1];
            if (player.CurrentItemIdx == player.CurrentItems.Count - 1)
            {
                player.CurrentItemIdx = 0;
            }
            else
            {
                player.CurrentItemIdx++;
            }
        }
    }

    private void GetPlayerMovementInput()
    {
        dirY = Input.GetAxisRaw("Vertical");
        dirX = Input.GetAxisRaw("Horizontal");   
        playerInput = new Vector2(dirX, dirY).normalized;
    }

    private void ApplyPlayerMovement(PlayerStateManager player)
    {
        moveDir = new Vector3(playerInput.x * moveSpeed * Time.fixedDeltaTime, playerInput.y * moveSpeed * Time.fixedDeltaTime, player.transform.position.z);
        player.RigidBody.velocity = moveDir;
    }

    private void ChangeCurrentAnimation(PlayerStateManager player)
    {
        player.Animator.SetFloat("X", dirX);
        player.Animator.SetFloat("Y", dirY);

        if (dirX != -1f)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
