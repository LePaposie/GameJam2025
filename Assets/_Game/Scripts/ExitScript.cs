using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void ExitGame()
    {
        // Si estamos en el editor de Unity
        UnityEditor.EditorApplication.isPlaying = false;

        // Si estamos ejecutando un build (ejecutable), cierra la aplicación
        Application.Quit();
        Debug.Log("El juego se ha cerrado."); // Mensaje en la consola
    }
}
