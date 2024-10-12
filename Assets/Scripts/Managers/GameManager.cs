using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private LevelManager currentLevel;
    private ControllerType controllerInUse = ControllerType.PS4;

    public ControllerType ControllerInUse => controllerInUse;

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
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {            
            QuitGame();
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

    private void PlayerDied()
    {
        SceneChanger.Instance.ChangeScene(currentLevel.LevelID);
    }

    private void LevelFinished()
    {
        SceneChanger.Instance.ChangeScene("MainMenu");
    }

    public void SetControllerType(ControllerType controllerType)
    {
        controllerInUse = controllerType;
        Debug.Log(controllerInUse);
    }

}
