using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
/// <summary>
/// La classe <c>generateEmpCrisisLines</c> g�n�re dynamiquement les lignes de la table pour afficher les conflits entre employ�s
/// dans l'interface utilisateur, en utilisant un prefab de ligne et des donn�es obtenues via le gestionnaire de crises (CrisisManager).
/// </summary>
public class generateEmpCrisisLines : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform contentParent;
    List<string[]> EmpConflictsList;
    public static CrisisManager Instance { get; private set; }

    /// <summary>
    /// M�thode appel�e au d�marrage pour initialiser les donn�es des conflits et g�n�rer la table.
    /// </summary>
    void Start()
    {
        EmpConflictsList = CrisisManager.Instance.GetAllConflictsString();
        CrisisManager.Instance.DisplayAllConflicts();
        GenerateTable();
    }
    /// <summary>
    /// M�thode utilis�e pour g�n�rer la table des conflits en instanciant des lignes pour chaque conflit.
    /// </summary>
    private void GenerateTable()
    {
        foreach (var stringTab in EmpConflictsList)
        {
            GameObject newRow = Instantiate(rowPrefab, contentParent);
            newRow.SetActive(true);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = stringTab[1] + " de " + stringTab[0];
            texts[1].text = stringTab[2] + " de " + stringTab[0];
        }
    }




}
