
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
    }

    public override void Update(PlayerController player)
    {
        player.horzMove = Input.GetAxisRaw("Horizontal");
        player.vertMove = Input.GetAxisRaw("Vertical");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.horzMove * player.speed, 0);
        /*
         if (Input.GetKey("left"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-player.speed * Time.deltaTime, 1.5f));
        }
        if (Input.GetKey("right"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.speed * Time.deltaTime, 1.5f));
        }
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, player.jumpforce));
            player.TransitionToState(player.AirMovingState);
        }
        // Input.GetKey("right") && !Input.GetKey("left")
        if (player.horzMove==0)
        {
            player.TransitionToState(player.IdleState);
        }
    }
}