using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // N�cessaire pour utiliser le Slider
/// <summary>
/// La classe <c>TipsMenu</c> g�re l'affichage d'un menu de conseils dans le jeu.
/// Les conseils s'affichent un par un, avec une barre de progression indiquant le temps restant pour chaque conseil.
/// L'utilisateur peut afficher ou masquer ce menu en utilisant les boutons associ�s.
/// </summary>
public class TipsMenu : MonoBehaviour
{
    public string tip0;
    public bool visible;
    private List<string> lstTip;
    public TextMeshProUGUI tiptext;
    public Slider progressBar; // Le slider de la barre de progression
    public float tipDuration = 5f; // Dur�e entre chaque tip
    public GameObject plusButton;
    public GameObject minusButton;
    public float moveDistance = 17.5f;  // Distance � d�placer

    /// <summary>
    /// M�thode appel�e au d�marrage du jeu.
    /// Initialise les conseils et configure le slider et les boutons.
    /// </summary>
    void Start()
    {
        visible = true;
        lstTip = new List<string>();
        tip0 = "Tips : ";
        lstTip.Add("Vous pouvez recruter des employ�s et les visualiser dans le trombinoscope de leur b�timent");
        lstTip.Add("Des crises peuvent survenir, visualisez souvent vos mails dans le b�timent central pour vous tenir inform�");
        lstTip.Add("Besoin de licencier, donner une prime ou m�me envoyer un employ� en formation -> B�timent central");
        lstTip.Add("Les employ�s perdent de leur esprit d'�quipe au fur et � mesure du temps, veillez � la coh�sion !");
        lstTip.Add("Vous pouvez perdre si votre r�putation est trop basse !");
        lstTip.Add("Vous pouvez perdre si vous �tes trop dans le n�gatif !");
        lstTip.Add("Seulement 6 semestres � tenir pour r�ussir votre carri�re");

        // Initialiser le slider
        if (progressBar != null)
        {
            progressBar.minValue = 0;
            progressBar.maxValue = tipDuration;
            progressBar.value = 0;
        }

        // Ajouter les listeners pour les boutons
        if (minusButton != null)
        {
            minusButton.GetComponent<Button>().onClick.AddListener(MinusClick);
        }

        StartCoroutine(ChangeTipsEvery3Seconds());
    }
    /// <summary>
    /// Coroutine qui change le tip affich� toutes les 3 secondes, en mettant � jour la barre de progression.
    /// </summary>
    IEnumerator ChangeTipsEvery3Seconds()
    {
        while (visible)
        {
            for (int i = 0; i < lstTip.Count; i++)
            {
                tiptext.text = tip0 + lstTip[i]; // Mise � jour du texte du tip
                yield return StartCoroutine(UpdateProgressBar()); // Met � jour la barre de progression
            }
        }
    }
    /// <summary>
    /// Coroutine qui met � jour la barre de progression en fonction du temps �coul� pour chaque tips.
    /// </summary>
    IEnumerator UpdateProgressBar()
    {
        float elapsedTime = 0f;

        // Faire monter la barre progressivement
        while (elapsedTime < tipDuration)
        {
            elapsedTime += Time.deltaTime;
            if (progressBar != null)
            {
                progressBar.value = elapsedTime;
            }
            yield return null; // Attend le prochain frame
        }

        // R�initialiser la barre pour le prochain tip
        if (progressBar != null)
        {
            progressBar.value = 0;
        }
    }
    /// <summary>
    /// M�thode appel�e lorsque le bouton moins est cliqu�. Masque le menu et d�place son objet.
    /// </summary>
    public void MinusClick()
    {
        visible = false;

        // Ajuster la position locale de l'objet
        transform.localPosition = new Vector3(transform.localPosition.x, -554f, transform.localPosition.z);
        minusButton.SetActive(false);
        plusButton.SetActive(true);
    }
    /// <summary>
    /// M�thode appel�e lorsque le bouton plus est cliqu�. Affiche le menu et d�place son objet.
    /// </summary>
    public void plusClick()
    {
        visible = true;

        // Ajuster la position locale de l'objet
        transform.localPosition = new Vector3(transform.localPosition.x, -490f, transform.localPosition.z);
        minusButton.SetActive(true);
        plusButton.SetActive(false);
    }


}
