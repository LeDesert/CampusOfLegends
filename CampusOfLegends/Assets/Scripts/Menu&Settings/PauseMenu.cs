using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// Ce script g�re le comportement du menu de pause, du menu des param�tres et du bouton "Next Semester" dans le jeu.
/// Il permet d'afficher ou de masquer le menu de pause et les param�tres en fonction des actions du joueur.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject nextSemesterButton;
    public static bool isPaused = false;
    /// <summary>
    /// V�rifie si la touche '�chap' a �t� press�e. Si c'est le cas, elle bascule entre l'�tat de pause et d'activation du menu de pause.
    /// Le bouton "Next Semester" est �galement cach� ou affich� en fonction de l'�tat du jeu.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "mapV3")
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
            nextSemesterButton.SetActive(!isPaused);

            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                nextSemesterButton.SetActive(true);
            }
        }
    }
    /// <summary>
    /// M�thode pour revenir au menu principal. Elle charge la sc�ne "menuPrincipal".
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene("menuPrincipal");
    }
    /// <summary>
    /// M�thode qui affiche le menu des param�tres.
    /// </summary>
    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
    }
    /// <summary>
    /// M�thode pour fermer le menu des param�tres.
    /// </summary>
    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }
    /// <summary>
    /// M�thode pour fermer le menu de pause et r�activer le bouton "Next Semester".
    /// </summary>
    public void ClosePauseMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        nextSemesterButton.SetActive(true);
    }
    /// <summary>
    /// M�thode pour basculer l'�tat du menu de pause en fonction de l'appui sur le bouton de pause dans le menu.
    /// </summary>
    public void SettingsButtonPressed()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        nextSemesterButton.SetActive(!isPaused);

    }
}
