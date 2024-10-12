using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControllerType : MonoBehaviour
{
    public void ChangeControllerTypeDropdown(int num)
    {
        switch(num)
        {
            case 0://PS4
                GameManager.Instance.SetControllerType(ControllerType.PS4);
                break;
            case 1://XBOX
                GameManager.Instance.SetControllerType(ControllerType.Xbox);
                break;
        }
    }
}
