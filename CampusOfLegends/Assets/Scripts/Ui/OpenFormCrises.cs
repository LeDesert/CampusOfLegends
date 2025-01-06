using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// La classe <c>OpenFormCrises</c> g�re l'ouverture et la fermeture du formulaire de crise dans l'interface utilisateur.
/// Elle est attach�e � un bouton qui, lorsqu'il est cliqu�, met � jour et affiche un formulaire de crise contenant des informations sp�cifiques sur la crise en cours.
/// </summary>
public class OpenFormCrises : MonoBehaviour
{
    public Button mainButton;
    public CrisisForm crisisForm;
    public string CrisisName;
    public string CrisisText;
    public bool ActivedButton;
    public int buildingIndex;
    public bool isOnFire;

    /// <summary>
    /// M�thode appel�e au d�marrage pour initialiser le bouton avec un listener qui ouvre le formulaire de crise lorsque le bouton est cliqu�.
    /// </summary>
    void Start()
    {

        if (mainButton != null)
        {
            mainButton.onClick.AddListener(() =>
            {
               crisisForm.UpdateForm(CrisisName, CrisisText, ActivedButton, buildingIndex, isOnFire);
                OnMainButtonClick();
            });
        }
        else
        {
            Debug.LogError("ButtonOpenForm: Missing references - MainButton not assigned.");
        }
    }

    /// <summary>
    /// M�thode permettant de configurer les donn�es de la crise (nom, texte, �tat du bouton, etc.) avant l'affichage.
    /// </summary>
    /// <param name="CrisisName">Nom de la crise � afficher.</param>
    /// <param name="CrisesText">Description de la crise � afficher.</param>
    /// <param name="ActivedBool">Indique si le bouton de la crise doit �tre activ� ou non.</param>
    /// <param name="cfm">R�f�rence au formulaire de crise.</param>
    /// <param name="buildingIndex">Index du b�timent concern� par la crise.</param>
    /// <param name="isOnFire">Indique si la crise concerne un incendie.</param>
    public void setData(string CrisisName, string CrisesText, bool ActivedBool, CrisisForm cfm, int buildingIndex, bool isOnFire)
    {
        this.CrisisName = CrisisName;
        this.CrisisText = CrisesText;
        this.ActivedButton = ActivedBool;
        this.crisisForm = cfm;
        this.buildingIndex = buildingIndex;
        this.isOnFire = isOnFire;
    }
    /// <summary>
    /// M�thode appel�e lorsque le bouton principal est cliqu�. Elle affiche le formulaire de crise.
    /// </summary>
    void OnMainButtonClick()
    {
        if (crisisForm != null)
        {
            crisisForm.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// M�thode pour fermer le formulaire de crise.
    /// </summary>
    public void CloseForm()
    {
        if (crisisForm != null)
        {
            crisisForm.gameObject.SetActive(false);
        }
    }

}
