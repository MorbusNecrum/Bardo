using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelButton : MonoBehaviour
{
    public void RestartLevelOnClicked()
    {
        GameManager.Instance.PauseToggle();
        GameManager.Instance.RestartLevel();
    }
    public void RestartLevelFromWinOnClicked()
    {
        GameManager.Instance.UnfreezeTime();
        GameManager.Instance.RestartLevel();
    }
}
