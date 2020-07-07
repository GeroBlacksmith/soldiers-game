using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirMovingState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
        player.TransitionToState(player.WalkingState);
    }

    public override void Update(PlayerController player)
    {
        if (Input.GetKey("left"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-player.speed * Time.deltaTime, 0));
        }
        if (Input.GetKey("right"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.speed * Time.deltaTime, 0));
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            player.TransitionToState(player.JumpingState);
        }
    }
}
