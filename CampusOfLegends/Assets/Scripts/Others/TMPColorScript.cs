using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette classe permet de changer la couleur d'un mat�riau au d�marrage du jeu.
/// Elle modifie la couleur du mat�riau attach� au GameObject en d�finissant sa couleur principale.
/// </summary>
public class TMPColorScript : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// M�thode appel�e au d�but de la sc�ne, au d�marrage du jeu.
    /// Cette m�thode r�cup�re le composant `Renderer` du GameObject et d�finit la couleur de son mat�riau.
    /// </summary>
    void Start()
    {
        Color couleur = Color.gray;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color",couleur);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
