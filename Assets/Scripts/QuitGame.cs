using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // Vérifie si la touche ESC est pressée
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quitte le jeu
            Application.Quit();
        }
    }
}
