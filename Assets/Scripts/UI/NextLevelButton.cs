using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevelOnClick()
    {
        GameManager.Instance.UnfreezeTime();
        GameManager.Instance.NextLevel();
    }
}
