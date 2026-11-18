using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public static event Action<string> OnSceneChanged;

    public string CurrentSceneName { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        Bootstrapper.OnBootstrapperInitialized += LoadMainScene;
    }

    private void OnDisable()
    {
        Bootstrapper.OnBootstrapperInitialized -= LoadMainScene;
    }

    void LoadMainScene()
    {
        SceneManager.LoadSceneAsync("GameplayUI", LoadSceneMode.Additive);

        AsyncOperation mainMenuLoad = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        CurrentSceneName = "MainMenu";
        OnSceneChanged?.Invoke("MainMenu");

        if (mainMenuLoad != null)
        {
            mainMenuLoad.completed += _ => SceneManager.UnloadSceneAsync("Bootstrapper");
        }
    }

    public void OnLevel1Load() => LoadLevel("Level1");

    public void OnLevel2Load() => LoadLevel("Level2");

    public void OnResultsScreenLoad() => LoadLevel("ResultsScreen");

    public void OnMainMenuLoad() => LoadLevel("MainMenu");

    public void OnQuitGame()
    {
        Application.Quit();
    }

    private void LoadLevel(string sceneName, bool unloadPrevious = true)
    {
        if (unloadPrevious && !string.IsNullOrEmpty(CurrentSceneName))
        {
            SceneManager.UnloadSceneAsync(CurrentSceneName);
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        CurrentSceneName = sceneName;

        OnSceneChanged?.Invoke(sceneName);
    }
}
