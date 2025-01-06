using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cette classe permet de g�rer le changement d'�tat des boutons et objets dans l'interface utilisateur.
/// Lorsqu'un bouton principal est cliqu�, certains objets sont activ�s et d'autres sont d�sactiv�s.
/// Cela permet de contr�ler la visibilit� de plusieurs �l�ments de l'interface utilisateur de mani�re dynamique.
/// </summary>
public class SwappingButtonsCentral : MonoBehaviour
{
    public Button mainButton;
    public GameObject enabling;
    public GameObject disabling1;
    public GameObject disabling2;
    public GameObject disablingForm;

    /// <summary>
    /// M�thode appel�e lorsqu'un clic sur le bouton principal se produit.
    /// Cette m�thode active et d�sactive les objets dans l'interface utilisateur en fonction de l'�tat du bouton.
    /// </summary>
    public void OnMainButtonClick()
    {
        enabling.gameObject.SetActive(true);
        disabling1.gameObject.SetActive(false);
        disabling2.gameObject.SetActive(false);
        disablingForm.gameObject.SetActive(false);
    }

}
