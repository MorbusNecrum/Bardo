using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private LevelManager currentLevel;
    private ControllerType controllerInUse = ControllerType.PS4;
    private bool isGamePaused = false;

    public ControllerType ControllerInUse => controllerInUse;
    public bool IsGamePaused => isGamePaused;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PauseToggle()
    {
        if (!DialogueManager.Instance.IsInDialogue)//Si NO esta en dialogo, ya q cuenta como pausa
        {
            if (!isGamePaused)//Si no esta pausado lo pausa
            {//PAUSA
                GameObject.Find("PausePanelParent").transform.GetChild(0).gameObject.SetActive(true);
                FreezeTime();
            }
            if (isGamePaused)//Si esta pausado lo despausa
            {//PLAY
                GameObject.Find("PausePanelParent").transform.GetChild(0).gameObject.SetActive(false);
                UnfreezeTime();
            }
            isGamePaused = !isGamePaused;
        }
    }

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    public void UnfreezeTime()
    {
        Time.timeScale = 1f;
    }

    public void ChangeTimeSpeed(float time)
    {
        Time.timeScale = time;
    }

    public void ReferenceLevelManager(LevelManager level)
    {
        currentLevel = level;
        currentLevel.OnKilledAllEnemies.AddListener(LevelFinished);
    }

    private void LevelFinished()
    {
        GameObject.Find("WinPanelParent").transform.GetChild(0).gameObject.SetActive(true);
        FreezeTime();
    }

    public void NextLevel()
    {
        SceneChanger.Instance.ChangeScene(currentLevel.NextLevelID);
    }

    public void RestartLevel()
    {
        SceneChanger.Instance.ChangeScene(currentLevel.LevelID);
    }

    public void RestartFromLastCheckpoint()
    {
        currentLevel.Respawn();
    }
    public void SetControllerType(ControllerType controllerType)
    {
        controllerInUse = controllerType;
        Debug.Log(controllerInUse);
    }

}
