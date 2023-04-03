using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovingState : PlayerBaseState
{
    // Movement Variables
    [SerializeField] private float moveSpeed = 200f;
    private Vector3 moveDir;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am Moving");
        player.Animator.SetBool("IsMoving", true);
        ChangeCurrentAnimation(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.PlayerInput.magnitude != 0f && player.IsInteracting == false)
        {
            ApplyPlayerMovement(player);
            ChangeCurrentAnimation(player);
        }
        else if (player.PlayerInput.magnitude == 0f && player.IsInteracting == false)
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

    private void ApplyPlayerMovement(PlayerStateManager player)
    {
        moveDir = new Vector3(player.PlayerInput.x * moveSpeed * Time.fixedDeltaTime, player.PlayerInput.y * moveSpeed * Time.fixedDeltaTime, player.transform.position.z);
        player.RigidBody.velocity = moveDir;
    }

    private void ChangeCurrentAnimation(PlayerStateManager player)
    {
        player.Animator.SetFloat("X", player.DirX);
        player.Animator.SetFloat("Y", player.DirY);

        if (player.DirX != -1f)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
