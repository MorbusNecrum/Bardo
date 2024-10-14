using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    public void OnClickChangeScene(string sceneName)
    {
        SceneChanger.Instance.ChangeScene(sceneName);
    }
}
