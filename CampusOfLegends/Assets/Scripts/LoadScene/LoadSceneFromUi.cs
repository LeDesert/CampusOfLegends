using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Ce script permet de charger une sc�ne en fonction du b�timent s�lectionn� via l'interface utilisateur.
/// Lorsque le joueur clique sur un bouton associ� � un b�timent, ce script d�termine la sc�ne correspondante � charger.
/// </summary>
public class LoadScenFromUi : MonoBehaviour
{
    public string sceneName;
    public int indexBat;


    /// <summary>
    /// M�thode appel�e lorsque l'utilisateur clique sur un bouton pour changer de sc�ne.
    /// </summary>
    public void ButtonClicked()
    {
        sceneName=TrombinoParam.caller;
        switch(sceneName)
        {
            case "Administratif":
                sceneName="Bat_Administration";
                break;
            case "Enseignant":
                sceneName="Bat_Enseignants";
                break;
            case "Entretient":
                sceneName="Bat_Entretien";
                break;
            case "Informatique":
                sceneName="Bat_Informatique";
                break;                
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
