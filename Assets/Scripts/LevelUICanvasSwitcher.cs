using UnityEngine;

public class LevelUICanvasSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class CanvasEntry
    {
        public string sceneName;
        public GameObject canvas;
    }

    [SerializeField] private CanvasEntry[] canvases;

    void OnEnable()
    {
        LevelManager.OnSceneChanged += Refresh;
    }

    void OnDisable()
    {
        LevelManager.OnSceneChanged -= Refresh;
    }

    void Start()
    {
        if (LevelManager.Instance != null)
        {
            Refresh(LevelManager.Instance.CurrentSceneName);
        }
    }

    public void Refresh(string sceneName)
    {
        foreach (var entry in canvases)
        {
            entry.canvas.SetActive(entry.sceneName == sceneName);
        }
    }
}
