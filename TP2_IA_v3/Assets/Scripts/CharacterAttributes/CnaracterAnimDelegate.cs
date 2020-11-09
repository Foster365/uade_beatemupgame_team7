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
        leftArmCollider.SetActive(false);
    }
    
    void RightArmAttackOn()
    {
        leftArmCollider.SetActive(true);
    }

    void RightArmAttackOff()
    {
        leftArmCollider.SetActive(false);
    }

    void LeftFootAttackOn()
    {
        leftArmCollider.SetActive(true);
    }

    void LeftFootAttackOff()
    {
        leftArmCollider.SetActive(false);
    }

    void RightFootAttackOn()
    {
        leftArmCollider.SetActive(true);
    }

    void RightFootAttackOff()
    {
        leftArmCollider.SetActive(false);
    }

}
