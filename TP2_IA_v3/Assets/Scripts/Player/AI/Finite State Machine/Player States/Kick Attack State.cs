using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KickAttackState<T>: FSMState<T>
{

    T _idleInput;
    T _punchInput;
    PlayerAnimation _anim;
    FSM<T> _fsm;
        
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    public KickAttackState(FSM<T> fsm, PlayerAnimation anim,T iI, T pI)
    {
        _fsm = fsm;        
        _idleInput = iI;
        _punchInput = pI;
        _anim = anim;
    }

    public override void Awake()
    {
       // Debug.Log("AttackState");
        _anim.Walk(false);
        
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
        _anim.Kick_1();

    }


    public override void Execute()
    {
        ComboAttacks();
        ResetComboState();

        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            _fsm.Transition(_idleInput);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _fsm.Transition(_punchInput);
        }
    }

    
    void ComboAttacks()
    {
               
        //Kick 
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_2) return;

            if (current_Combo_State == ComboState.NONE || current_Combo_State == ComboState.PUNCH_1 || current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }
            else if(current_Combo_State == ComboState.KICK_1)
            {
                current_Combo_State++;
            }
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.KICK_1)
            {
                _anim.Kick_1();
            }

            if (current_Combo_State == ComboState.KICK_2)
            {
                _anim.Kick_2();
            }
        }
                       
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            //Debug.Log("Reset entered");
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                
                current_Combo_State = ComboState.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
                
            }
        }
    }
}
