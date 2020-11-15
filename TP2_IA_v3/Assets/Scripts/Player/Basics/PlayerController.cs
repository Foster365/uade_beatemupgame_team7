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

        IdleState<string> idle = new IdleState<string>(_fsm, player_anim,"Move", "Punch Attack", "Kick Attack");
        MoveState<string> move = new MoveState<string>(_player, _fsm, player_anim, "Attack", "Idle");
        //JumpState<string> jump = new JumpState<string>(_fsm, "Idle", _rb, _player);
        PunchAttackState<string> punchAttack = new PunchAttackState<string>(_fsm, player_anim, "Idle", "Kick Attack");
        KickAttackState<string> kickAttack = new KickAttackState<string>(_fsm, player_anim, "Idle", "Punch Attack");


        idle.AddTransition("Move", move);
        idle.AddTransition("Punch Attack", punchAttack);
        idle.AddTransition("Kick Attack", kickAttack);

        move.AddTransition("Idle", idle);
        move.AddTransition("Punch Attack", punchAttack);
        move.AddTransition("Kick Attack", kickAttack);

        //jump.AddTransition("Idle", idle);

        punchAttack.AddTransition("Idle", idle);
        punchAttack.AddTransition("Kick Attack", kickAttack);

        kickAttack.AddTransition("Idle", idle);
        kickAttack.AddTransition("Punch Attack", punchAttack);

        _fsm.SetInit(idle);
    }
    void Update()
    {
        _fsm.OnUpdate();
        _healthUI.DisplayPlayerHealth(_player.currentHealth);
    }
}
