using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe <c>empLine</c> g�re les actions li�es � un employ� dans une interface utilisateur.
/// Elle permet d'effectuer diff�rentes actions comme l'ajout de primes, l'envoi en formation,
/// et le licenciement d'un employ�. Chaque action met � jour les donn�es de l'employ� et ajuste
/// les ressources du jeu.
/// </summary>
public class empLine : MonoBehaviour
{
    private EmployeeData _emp;

    /// <summary>
    /// M�thode appel�e lors du clic sur un bouton dans l'interface.
    /// </summary>
    /// <param name="button">L'identifiant du bouton cliqu� (0 = ajouter prime, 1 = envoyer en formation, 2 = licencier).</param>
    public void OnButtonClick(int button)
    {
        if (button == 0)
        {
            addPrime();

        }
        else if (button == 1)
        {
            sendForTaining();

        }
        else if (button == 2)
        {
            fired();

        }
        CloseConfirmation.InstanceConfirmation.setConfirmationMenuActive();
        CanvasUpdater.Instance.UpdateCanvas();
    }

    /// <summary>
    /// M�thode pour d�finir les donn�es de l'employ� � afficher ou modifier.
    /// </summary>
    /// <param name="empData">Les donn�es de l'employ�.</param>
    public void setEmpData(EmployeeData empData)
    {
        this._emp = empData;
    }

    /// <summary>
    /// M�thode pour ajouter une prime � un employ�. Un montant al�atoire est attribu� � la prime,
    /// et une somme est d�duite des ressources du jeu.
    /// </summary>
    public void addPrime()
    {
        float randomValue = Random.Range(0.5f, 1.5f);
        EmployeeManager.Instance.addPrime(randomValue, this._emp);
        ResourceManager.Instance.AddMoney(-1000);
    }

    /// <summary>
    /// M�thode pour envoyer un employ� en formation. L'efficacit� au travail et la coh�sion de l'�quipe
    /// de l'employ� sont am�lior�es avec des valeurs al�atoires, et des ressources sont d�duites.
    /// </summary>
    private void sendForTaining()
    {
        float randomValue1 = Random.Range(0.5f, 1.5f);
        EmployeeManager.Instance.moreWorkEfficiency( randomValue1, this._emp);
        float randomValue2 = Random.Range(0.5f, 1.5f);
        EmployeeManager.Instance.moreTeamEfficiency( randomValue2, this._emp);
        ResourceManager.Instance.AddMoney(-4000);
        if (CrisisManager.Instance != null)
        {
            CrisisManager.Instance.RemoveFromConflicts(this._emp);
        }
    }
    /// <summary>
    /// M�thode pour licencier un employ�. L'employ� est retir� de la gestion et les ressources sont ajust�es.
    /// </summary>
    private void fired()
    {
        if (_emp != null && EmployeeManager.Instance != null)
        {
            EmployeeManager.Instance.FireEmployee(_emp.job, _emp);
            Debug.Log("Employee fired: " + _emp.GetFirstName() + " " + _emp.GetLastName());
            EmployeeTableManager.Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Employee data or EmployeeManager instance is null.");
        }
    }
}
