using UnityEngine;
using System.Runtime.InteropServices;

public class AltF4Blocker : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    [DllImport("AltF4Interceptor")]
    private static extern void BlockAltF4();
    [DllImport("AltF4Interceptor")]
    private static extern void UnblockAltF4();
#endif

    [Header("UI References")]
    [SerializeField] private CanvasGroup quitConfirmationUI;
    [SerializeField] private float fadeDuration = 0.15f;

    [Header("Settings")]
    [SerializeField] private bool pauseGameWhenUIVisible = true;

    private bool isQuitUIActive = false;
    private bool dllInitialized = false;

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        try
        {
            BlockAltF4();
            dllInitialized = true;
        }
        catch { dllInitialized = false; }
#endif

        // Force enable GameObject but make it invisible
        if (quitConfirmationUI != null)
        {
            quitConfirmationUI.gameObject.SetActive(true); // CRUCIAL LINE
            quitConfirmationUI.alpha = 0;
            quitConfirmationUI.interactable = false;
            quitConfirmationUI.blocksRaycasts = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            ToggleQuitUI();
        }

        UpdateUIState();
    }

    private void ToggleQuitUI()
    {
        isQuitUIActive = !isQuitUIActive;

        if (pauseGameWhenUIVisible)
        {
            Time.timeScale = isQuitUIActive ? 0f : 1f;
            AudioListener.pause = isQuitUIActive;
        }
    }

    private void UpdateUIState()
    {
        if (quitConfirmationUI == null) return;

        // Always keep the GameObject active
        quitConfirmationUI.gameObject.SetActive(true);

        // Smooth fade
        float targetAlpha = isQuitUIActive ? 1f : 0f;
        quitConfirmationUI.alpha = Mathf.MoveTowards(
            quitConfirmationUI.alpha,
            targetAlpha,
            Time.unscaledDeltaTime / fadeDuration
        );

        // Only enable interaction when fully visible
        bool fullyVisible = quitConfirmationUI.alpha >= 0.99f;
        quitConfirmationUI.interactable = fullyVisible && isQuitUIActive;
        quitConfirmationUI.blocksRaycasts = fullyVisible && isQuitUIActive;
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE_WIN
        if (dllInitialized) UnblockAltF4();
#endif
        Application.Quit();
    }

    public void CancelQuit()
    {
        isQuitUIActive = false;
    }

    private void OnDestroy()
    {
#if UNITY_STANDALONE_WIN
        if (dllInitialized) UnblockAltF4();
#endif
    }
}