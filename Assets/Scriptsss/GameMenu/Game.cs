
using UnityEditor;

using UnityEngine.SceneManagement;

public static class Game
{
    public static void Continue()
    {
        SceneManager.LoadSceneAsync("langtone");
        gameManager.Instance.IsPlaygame = true;
    }
    public static void Quit()
    {
        confirmPanel.Ask("Are you sure you want to quit game?", QuitImediately);
    }
    public static void QuitImediately()
    {
        // EventManager.RaiseEvent("OnGameSave");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
        
#endif
    }
}