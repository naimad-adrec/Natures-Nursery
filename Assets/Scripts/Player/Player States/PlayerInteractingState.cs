using System.Collections;
using UnityEngine;

public class PlayerInteractingState : PlayerBaseState
{
    private float animationTime;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am Interacting");
        player.Animator.SetBool("IsMoving", false);
        ChangeCurrentAnimation(player);
        ChangeCurrentItemFillRate(player);

        // Set animation time based off current item
        if (player.CurrentItem == "Watering Can")
        {
            animationTime = 1f;

            // Start coroutine to wait for animation to finish
            player.StartCoroutine(WaitForInteractAnimation(player, animationTime));
        }
        else if (player.CurrentItem == "Seed Bag")
        {
            player.OpenSeedBag.Invoke();
        }
        else if (player.CurrentItem == "Soil Bag")
        {
            animationTime = 3f;
        }
        else if (player.CurrentItem == "Magnifying Glass")
        {
            animationTime = 4f;
        }
        else
        {
            animationTime = 5f;
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsInteracting == true)
        {
            if (player.CurrentItem == "Seed Bag")
            {

            }
            else if (player.CurrentItem == "Soil Bag")
            {

            }
            else if (player.CurrentItem == "Magnifying Glass")
            {

            }
        }
        else
        {
            player.SwitchState(player.IdleState);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    private void ChangeCurrentItemFillRate(PlayerStateManager player)
    {
        if (player.CurrentItem == "Watering Can")
        {
            player.WaterPercentage -= 20f;
        }
        else if (player.CurrentItem == "Soil Bag")
        {

        }
    }

    private void ChangeCurrentAnimation(PlayerStateManager player)
    {
        // Set Direction of animation
        player.Animator.SetFloat("X", player.LastDirX);
        player.Animator.SetFloat("Y", player.LastDirY);

        // Transition to interacting state machine
        player.Animator.SetBool("IsInteracting", true);

        // Set animation based of current item equipped
        player.Animator.SetInteger("CurrentItem", player.CurrentItemIdx);

        if(player.WaterPercentage > 0f)
        {
            player.Animator.SetBool("IsFull", true);
        }
        else
        {
            player.Animator.SetBool("IsFull", false);
        }

        // Flip sprite direction based on last given input
        if (player.LastDirX != -1f)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private IEnumerator WaitForInteractAnimation(PlayerStateManager player, float time)
    {
        yield return new WaitForSeconds(time);
        player.Animator.SetBool("IsInteracting", false);
        player.IsInteracting = false;
    }
}