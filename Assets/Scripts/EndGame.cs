using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
    public static event Action GameOver;

    [SerializeField] private GameObject _panel;

    private void Awake() => Instance = this;

    private void Start()
    {
        Time.timeScale = 1;
        _panel.SetActive(false);
    }

    public void End()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
        _panel.SetActive(true);
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonQuit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#elif UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}