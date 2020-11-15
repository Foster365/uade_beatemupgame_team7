using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    FSM<string> _fsm;
    Rigidbody _rb;
    Player _player;
    public PlayerAnimation player_anim;

    HealthUI _healthUI;

    void Start()
    {
        player_anim = GetComponentInChildren<PlayerAnimation>();
        _rb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _fsm = new FSM<string>();

        _healthUI = gameObject.GetComponentInChildren<HealthUI>();

        IdleState<string> idle = new IdleState<string>(_fsm, player_anim,"Move", "Attack");
        MoveState<string> move = new MoveState<string>(_player, _fsm, player_anim, "Attack", "Idle");
        //JumpState<string> jump = new JumpState<string>(_fsm, "Idle", _rb, _player);
        AttackState<string> attack = new AttackState<string>(_fsm, player_anim, "Idle");

       
        idle.AddTransition("Move", move);
        idle.AddTransition("Attack", attack);

        move.AddTransition("Idle", idle);
        move.AddTransition("Attack", attack);

        //jump.AddTransition("Idle", idle);

        attack.AddTransition("Idle", idle);

        _fsm.SetInit(idle);
    }
    void Update()
    {
        _fsm.OnUpdate();
        _healthUI.DisplayHealth(_player.currentHealth);
    }
}
