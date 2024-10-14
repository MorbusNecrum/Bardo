using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenuButton : MonoBehaviour
{

    public void ToMainMenuOnClicked()
    {
        GameManager.Instance.PauseToggle();
        SceneChanger.Instance.ChangeScene("MainMenu");
    }
}
