using UnityEngine;


/// <summary>
/// Ce script g�re la mise en pause du jeu en activant et d�sactivant les menus de pause et de param�tres.
/// Il permet de basculer entre les menus de pause et de param�tres � l'aide de la touche '�chap'.
/// </summary>
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;


    /// <summary>
    /// M�thode appel�e � chaque frame pour v�rifier les entr�es de l'utilisateur.
    /// Elle permet de basculer entre les menus de pause et de param�tres lorsque l'utilisateur appuie sur la touche '�chap'.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
            }
        }
    }
}