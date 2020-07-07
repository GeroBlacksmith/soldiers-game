using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }
    // STATES
    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerJumpingState JumpingState = new PlayerJumpingState();
    public readonly PlayerAirMovingState AirMovingState = new PlayerAirMovingState();

    public Rigidbody2D rigidBody;

    public float effectiveHorizontalMovement = 0f;
    public float effectiveVerticalMovement = 0f;
    public float speed = 200f;
    public float jumpforce = 200f;
    public float horzMove = 0;
    public float vertMove = 0;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(IdleState);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    } 

    public void TransitionToState(PlayerBaseState state) {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState);
    }

}
