using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CnaracterAnimDelegate : MonoBehaviour
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

}
