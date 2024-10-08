using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        SceneChanger.Instance.ChangeScene(sceneName);
    }
}
