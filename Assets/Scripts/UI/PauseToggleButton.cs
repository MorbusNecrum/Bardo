using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToggleButton : MonoBehaviour
{
    public void OnClicked()
    {
        GameManager.Instance.PauseToggle();
    }
}
