using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
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
        // Boton de caminar
        // Input.GetKey("left") || Input.GetKey("right")
        if (player.horzMove!=0)
        {
            player.TransitionToState(player.WalkingState);
        }
        //
        //  player.TransitionToState(player.WalkingState)
        // Boton de saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  Logica de saltar
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, player.jumpforce));
            // TRANSITION
            player.TransitionToState(player.JumpingState);
        }
       
        //  player.TransitionToState(player.JumpingState)
        /*
         float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // jumping logic
            player.rigidBody.AddForce(Vector2.up);
            // TRANSITION
            player.TransitionToState(player.JumpingState);
        }
        Vector2 vect = player.rigidBody.velocity;

        player.effectiveVerticalMovement = vect.y;
        player.effectiveHorizontalMovement = horzMove * player.speed;



        player.rigidBody.velocity = new Vector2(player.effectiveHorizontalMovement, player.effectiveVerticalMovement);
        */


    }
}