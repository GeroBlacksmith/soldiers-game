using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState: PlayerBaseState
{

    public override void EnterState(PlayerController player)
    {
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
        player.TransitionToState(player.IdleState);
    }

    public override void Update(PlayerController player)
    {
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            player.TransitionToState(player.AirMovingState);
        }
    }
}