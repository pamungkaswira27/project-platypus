using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] CanvasGroup overlay;
    [SerializeField] CanvasGroup endPanel;

    void OnEnable()
    {
        overlay.alpha = 0f;
        endPanel.alpha = 0f;

        overlay.DOFade(1f, 1f);
        endPanel.DOFade(1f, 1f);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
