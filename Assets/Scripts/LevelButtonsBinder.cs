using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsBinder : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button resultsButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        var lm = LevelManager.Instance;
        if (lm == null) return;

        if (level1Button != null) level1Button.onClick.AddListener(lm.OnLevel1Load);
        if (level2Button != null) level2Button.onClick.AddListener(lm.OnLevel2Load);
        if (resultsButton != null) resultsButton.onClick.AddListener(lm.OnResultsScreenLoad);
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(lm.OnMainMenuLoad);
        if (quitButton != null) quitButton.onClick.AddListener(lm.OnQuitGame);
    }
}