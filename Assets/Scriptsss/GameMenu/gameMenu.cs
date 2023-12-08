
using UnityEngine;

public class gameMenu : MonoBehaviour
{
    public void quitGame()
    {
        Game.Quit();
    }
    public void continueGame()
    {
        Game.Continue();
    }
    void OnGUI()
    {
        // Tạo một nút bấm ở vị trí (10, 10) với kích thước (150, 30)
        if (GUI.Button(new Rect(10, 10, 150, 30), "Click Me"))
        {
            // Xử lý sự kiện khi nút được bấm
            Debug.Log("Button Clicked!");
        }
    }
}
