using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    /// <summary>
    /// M�thode appel�e lors du clic pour revenir au menu principal.
    /// Elle effectue les �tapes suivantes :
    /// - Envoie le joueur hors de la carte en cours.
    /// - R�initialise le jeu � son �tat initial.
    /// - Charge la sc�ne du menu principal.
    /// </summary>
    public void OnClickBackToMainMenu()
    {
        PlayerController gameObject = GameObject.Find("Player").GetComponent<PlayerController>();
        gameObject.ToOutMap();
        ResetGame();
        SceneManager.LoadScene("menuPrincipal");
    }

    /// <summary>
    /// R�initialise le jeu � son �tat initial pour pouvoir recommencer une partie.
    /// Les actions effectu�es sont :
    /// - R�initialisation des ressources du jeu (argent, popularit�, attractivit�, efficacit�).
    /// - Suppression des employ�s.
    /// - R�initialisation des crises.
    /// - R�initialisation de la position du joueur.
    /// </summary>
    private void ResetGame()
    {
        Debug.Log("Reset Game");
        PauseMenu.isPaused = false;
        // R�initialisation des ressources (argent, popularit�, attractivit�, efficacit�)
        ResourceManager resourceManager = GameObject.Find("GameManager").GetComponent<ResourceManager>();
        if (resourceManager == null)
        {
            Debug.LogError("ResourceManager not found");
            return;
        }
        else
        {
            resourceManager.ResetRessource();
        }
        // Suppression des employ�s
        EmployeeManager empMng = GameObject.Find("GameManager").GetComponent<EmployeeManager>();
        if (empMng == null)
        {
            Debug.LogError("EmployeeManager not found");
            return;
        }
        else
        {
            empMng.ResetEmployees();
        }
 
        // R�initialisation des crises
        CrisisManager.Instance.ResetAllCrisis();

        PlayerPositionManager playerPositionManager = GameObject.Find("GameManager").GetComponent<PlayerPositionManager>();
        if (playerPositionManager == null)
        {
            Debug.LogError("PlayerPositionManager not found");
            return;
        }
        else
        {
            playerPositionManager.ResetPosition();
        }

    }
}
