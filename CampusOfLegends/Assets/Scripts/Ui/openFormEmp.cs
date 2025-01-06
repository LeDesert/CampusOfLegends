using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// La classe <c>ButtonOpenForm</c> g�re l'interaction entre un bouton et un formulaire d'employ�. 
/// Elle permet d'ouvrir et de fermer le formulaire d'employ� avec une animation associ�e, et met � jour les informations affich�es dans le formulaire en fonction des donn�es de l'employ�.
/// </summary>
public class ButtonOpenForm : MonoBehaviour
{
    public Animator animator;
    public Button mainButton;
    public EmployeeForm employeeForm;
    public string employeeName; 
    public float efficiency;
    public float team;
    public int salary;
    public float fidelity;
    /// <summary>
    /// M�thode appel�e au d�marrage pour configurer l'interaction entre le bouton et le formulaire.
    /// Elle ajoute un listener au bouton pour ouvrir le formulaire avec les informations de l'employ� lorsque le bouton est cliqu�.
    /// </summary>
    void Start()
    {
        if (mainButton != null && animator != null)
        {
            mainButton.onClick.AddListener(() =>
            {
                Debug.Log("Button clicked, toggling animation.");
                employeeForm.UpdateForm(employeeName,salary,efficiency,team, fidelity);
                OnMainButtonClick();
            });
        }
        else
        {
            Debug.LogError("ButtonOpenForm: Missing references - MainButton or Animator not assigned.");
        }
    }
    /// <summary>
    /// M�thode appel�e lorsque le bouton est cliqu�. Elle d�clenche l'animation d'ouverture ou de fermeture du formulaire en inversant l'�tat de l'animation.
    /// </summary>
    void OnMainButtonClick()
    {
        if (animator != null)
        {
            bool currentState = animator.GetBool("IsOpening");
            Debug.Log($"Current IsOpening: {currentState}, toggling to {!currentState}");
            animator.SetBool("IsOpening", !currentState);
        }
    }
    /// <summary>
    /// M�thode permettant d'assigner les r�f�rences du bouton principal et de l'animator � la classe.
    /// </summary>
    /// <param name="button">Le bouton principal qui d�clenche l'ouverture du formulaire.</param>
    /// <param name="anim">L'animator utilis� pour l'animation du formulaire.</param>
    public void AssignReferences(Button button, Animator anim)
    {
        mainButton = button;
        animator = anim;
    }
    /// <summary>
    /// M�thode pour fermer le formulaire d'employ�. Elle d�sactive l'animation d'ouverture et cache le formulaire.
    /// </summary>
    public void CloseForm()
{
    if (animator != null)
    {
        Debug.Log("Current IsOpening toggling to false");
        animator.SetBool("IsOpening", false);
        if (employeeForm != null)
        {
            employeeForm.gameObject.SetActive(false);
        }
    }
}

}
