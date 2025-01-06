using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// La classe <c>CloseConfirmation</c> g�re l'activation et la d�sactivation du menu de confirmation dans l'interface utilisateur.
/// Elle permet de montrer ou cacher un menu de confirmation lorsqu'une action n�cessite une confirmation de l'utilisateur.
/// </summary>
public class CloseConfirmation : MonoBehaviour
{
    public static CloseConfirmation InstanceConfirmation;
    public GameObject ConfirmationMenu;

    // Start is called before the first frame update
    void Start()
    {
        InstanceConfirmation = this;
    }

    public void setConfirmationMenuActive()
    {
        ConfirmationMenu.SetActive(true);
    }


    public void onClick()
    {
        ConfirmationMenu.SetActive(false);
    }
}
