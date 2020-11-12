using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimDelegate : MonoBehaviour
{

    public GameObject leftArmCollider, rightArmCollider, leftFootCollider, rightFootCollider;

    void LeftArmAttackOn()
    {
        leftArmCollider.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if(leftArmCollider.activeInHierarchy)
            leftArmCollider.SetActive(false);
    }
    
    void RightArmAttackOn()
    {
        rightArmCollider.SetActive(true);
    }

    void RightArmAttackOff()
    {
        if (rightArmCollider.activeInHierarchy)
            leftArmCollider.SetActive(false);
    }

    void LeftFootAttackOn()
    {
        leftFootCollider.SetActive(true);
    }

    void LeftFootAttackOff()
    {
        if (leftFootCollider.activeInHierarchy)
            leftFootCollider.SetActive(false);
    }

    void RightFootAttackOn()
    {
        rightFootCollider.SetActive(true);
    }

    void RightFootAttackOff()
    {
        if (rightFootCollider.activeInHierarchy)
            rightFootCollider.SetActive(false);
    }

    void TagLeftArm()
    {
        leftArmCollider.tag = CharacterTags.LEFT_ARM_TAG;
    }

    void UntagLeftArm()
    {
        leftArmCollider.tag = UtilitiesTags.UNTAGGED_TAG;
    }

    void TagLeftFoot()
    {
        leftFootCollider.tag = CharacterTags.LEFT_FOOT_TAG;
    }

    void UntagLeftFoot()
    {
        leftFootCollider.tag = UtilitiesTags.UNTAGGED_TAG;
    }

}
