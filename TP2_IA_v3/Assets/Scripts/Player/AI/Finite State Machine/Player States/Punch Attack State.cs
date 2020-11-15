using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState { NONE, PUNCH_1, PUNCH_2, PUNCH_3, KICK_1, KICK_2 }

public class PunchAttackState<T>: FSMState<T>
{

    T _idleInput;
    T _kickInput;
    PlayerAnimation _anim;
    FSM<T> _fsm;
        
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    public PunchAttackState(FSM<T> fsm, PlayerAnimation anim,T iI, T kI)
    {
        _fsm = fsm;        
        _idleInput = iI;
        _kickInput = kI;
        _anim = anim;
    }

    public override void Awake()
    {
       // Debug.Log("AttackState");
        _anim.Walk(false);
        
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
        _anim.Punch_1();

    }


    public override void Execute()
    {
        ComboAttacks();
        ResetComboState();

        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            _fsm.Transition(_idleInput);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _fsm.Transition(_kickInput);
        }
    }

    
    void ComboAttacks()
    {
        //Punch 
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_1 || current_Combo_State == ComboState.KICK_2) return;
            
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.PUNCH_1)
            {
                _anim.Punch_1();
            }
            if (current_Combo_State == ComboState.PUNCH_2)
            {
                _anim.Punch_2();
            }
            if (current_Combo_State == ComboState.PUNCH_3)
            {
                _anim.Punch_3();
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
