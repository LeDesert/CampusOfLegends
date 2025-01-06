using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cette classe g�re le comportement du bouton principal.
/// Lorsqu'on clique sur ce bouton, elle active ou d�sactive un effet de glissement sur un autre objet via un Animator.
/// </summary>
public class ButtonSlide : MonoBehaviour
{
    public Animator animator;
    public Button mainButton;

    /// <summary>
    /// M�thode appel�e au d�marrage pour lier l'�v�nement de clic du bouton principal.
    /// </summary>
    void Start()
    {
        mainButton.onClick.AddListener(OnMainButtonClick);
    }

    /// <summary>
    /// M�thode appel�e lors du clic sur le bouton principal.
    /// Elle active ou d�sactive l'animation de glissement en fonction de l'�tat actuel de l'Animator.
    /// </summary>
    void OnMainButtonClick()
    {
        animator.SetBool("IsSliding", !animator.GetBool("IsSliding"));
    }
}
