using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFromCheckpointButton : MonoBehaviour
{
    public void RestartFromCheckpointOnClicked()
    {
        GameManager.Instance.PauseToggle();
        GameManager.Instance.RestartFromLastCheckpoint();
    }
}
