using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    /// <summary>
    /// M�thode appel�e lors du clic pour quitter le jeu.
    /// Cette m�thode utilise <see cref="Application.Quit"/> pour fermer l'application.
    /// Note : Cette action fonctionne uniquement dans une build standalone 
    /// et ne fonctionne pas dans l'�diteur Unity.
    /// </summary>
    public void OnClickExit()
    {
        Application.Quit();
    }

}


