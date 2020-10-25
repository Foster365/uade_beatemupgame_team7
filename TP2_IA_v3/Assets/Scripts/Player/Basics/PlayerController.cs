using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    FSM<string> _fsm;
    Rigidbody _rb;
    Player _player;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _fsm = new FSM<string>();
        IdleState<string> idle = new IdleState<string>(_fsm, "Move", "Jump");
        MoveState<string> move = new MoveState<string>(_player, _fsm, "Jump", "Idle");
        JumpState<string> jump = new JumpState<string>(_fsm, "Idle", _rb, _player);

        //FSMStatePRO<string> fsmStatePRO = new FSMStatePRO<string>();
        //fsmStatePRO.OnExecute = MoveState;

        idle.AddTransition("Move", move);
        idle.AddTransition("Jump", jump);

        move.AddTransition("Idle", idle);
        move.AddTransition("Jump", jump);

        jump.AddTransition("Idle", idle);

        _fsm.SetInit(idle);
    }
    void Update()
    {
        _fsm.OnUpdate();
    }
}
