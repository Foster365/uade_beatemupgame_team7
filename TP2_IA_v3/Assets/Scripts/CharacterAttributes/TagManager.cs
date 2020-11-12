using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTags
{

    public const string ENEMY_MOVEMENT = "Moving";

    public const string ENEMY_APUNCH = "APunch";
    public const string ENEMY_BPUNCH = "BPunch";
    public const string ENEMY_KICK = "Kick";
    public const string ENEMY_BLOCK = "Block";

    public const string ENEMY_IDLE = "Idle";
    public const string ENEMY_DAMAGED = "Damaged";
    public const string ENEMY_DEATH = "Death";

}

public class CharacterTags
{

    public const string ENEMY_TAG = "Enemy";
    public const string PLAYER_TAG = "Player";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string LEFT_FOOT_TAG = "LeftFoot";
    public const string RIGHT_FOOT_TAG = "RightFoot";

}

public class UtilitiesTags
{

    public const string GROUND_TAG = "Ground";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI_TAG = "HealthUI";
    public const string UNTAGGED_TAG = "Untagged";

}