using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // V�rifie si la touche ESC est press�e
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quitte le jeu
            Application.Quit();
        }
    }
}
