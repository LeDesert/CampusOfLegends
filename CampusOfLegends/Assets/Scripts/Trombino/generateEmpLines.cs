using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// La classe <c>EmployeeTableManager</c> est responsable de l'affichage et de la mise � jour du tableau des employ�s.
/// Elle g�n�re dynamiquement des lignes pour chaque employ� et permet de rafra�chir le tableau si n�cessaire.
/// </summary>
public class EmployeeTableManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform contentParent;

    private List<EmployeeData> employees;
    public static EmployeeManager Instance { get; private set; }


    /// <summary>
    /// M�thode appel�e au d�marrage du jeu. Elle r�cup�re tous les employ�s et g�n�re le tableau.
    /// </summary>
    private void Start()
    {
        employees = EmployeeManager.Instance.GetAllEmployees();

        GenerateTable();
    }

    /// <summary>
    /// M�thode pour g�n�rer le tableau des employ�s. Pour chaque employ�, une ligne est instanci�e et ajout�e � l'interface.
    /// </summary>
    private void GenerateTable()
    {
        foreach (var employee in employees)
        {
            GameObject newRow = Instantiate(rowPrefab, contentParent);
            newRow.SetActive(true);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = employee.GetLastName();
            if (employee.GetJob() == "Entretient")
            {
                texts[1].text = "Entretien";
            }
            else { 
            texts[1].text = employee.GetJob();
            }
            texts[2].text = employee.GetFirstName();

            empLine emp = newRow.GetComponent<empLine>();
            if (emp != null)
            {
                emp.setEmpData(employee);
            }
        }
    }

    /// <summary>
    /// M�thode pour rafra�chir le tableau en supprimant les anciennes lignes et en g�n�rant un nouveau tableau.
    /// </summary>
    public void RefreshTable()
    {
        foreach(Transform child in contentParent)
        {
            Destroy(child.gameObject);
            Debug.Log("Destroying child");
        }
        employees = EmployeeManager.Instance.GetAllEmployees();

        GenerateTable();
    }

    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
    //    {
    //        RefreshTable();
    //    }
    //}

}
