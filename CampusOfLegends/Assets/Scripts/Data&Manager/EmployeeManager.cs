using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

/// <summary>
/// <c>EmployeeManager</c> est responsable de la gestion de toutes les donn�es des employ�s,
/// de l'embauche, du licenciement et du calcul des efficacit�s. Il garde une trace des r�les des
/// employ�s, des listes de recrutement et g�re la performance des employ�s, y compris l'efficacit�
/// au travail et l'efficacit� de l'�quipe. Il interagit �galement avec d'autres syst�mes comme le
/// <c>CrisisManager</c> pour la gestion des gr�ves et le suivi des d�missions des employ�s.
/// </summary>
public class EmployeeManager : MonoBehaviour
{
    public static EmployeeManager Instance { get; private set; }

    // listes des employ�s qu'on a recrut�s
    public List<EmployeeData> adminEmployees = new List<EmployeeData>();
    public List<EmployeeData> teacherEmployees = new List<EmployeeData>();
    public List<EmployeeData> maintenanceEmployees = new List<EmployeeData>();
    public List<EmployeeData> itEmployees = new List<EmployeeData>();

    // listes des employ�s propos�s dans les batiments
    public List<EmployeeData> adminRecruitmentList = new List<EmployeeData>();
    public List<EmployeeData> teacherRecruitmentList = new List<EmployeeData>();
    public List<EmployeeData> maintenanceRecruitmentList = new List<EmployeeData>();
    public List<EmployeeData> itRecruitmentList = new List<EmployeeData>();

    private static float maxGrade = 5;

    // <summary>
    // Coefficients d'efficacit� pour chaque b�timent
    // </summary>
    [SerializeField]
    private List<BuildingEfficiency> buildingEfficiencies = new List<BuildingEfficiency>
    {
        new BuildingEfficiency { buildingName = "Administratif", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.8f, nbEmployeeMeta = 4 },
        new BuildingEfficiency { buildingName = "Enseignant", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.7f, nbEmployeeMeta = 6 },
        new BuildingEfficiency { buildingName = "Entretient", workEfficiencyCoefficient = 0.4f, teamEfficiencyCoefficient = 0.6f, nbEmployeeMeta = 3},
        new BuildingEfficiency { buildingName = "Informatique", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.4f, nbEmployeeMeta = 4 }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Retourne la liste des employ�s propos�s pour recrutement en fonction du poste demand�.
    /// </summary>
    /// <param name="job">Le r�le pour lequel obtenir la liste de recrutement (par exemple, "Administratif", "Enseignant").</param>
    /// <returns>Une liste d'objets <c>EmployeeData</c> correspondant aux employ�s propos�s pour recrutement pour ce r�le.</returns>
    public List<EmployeeData> GetRecruitmentList(string job)
    {
        switch (job)
        {
            case "Administratif":
                return adminRecruitmentList;
            case "Enseignant":
                return teacherRecruitmentList;
            case "Entretient":
                return maintenanceRecruitmentList;
            case "Informatique":
                return itRecruitmentList;
            default:
                return new List<EmployeeData>();
        }
    }

    /// <summary>
    /// Retourne la liste des employ�s actuellement employ�s pour un poste sp�cifique.
    /// </summary>
    /// <param name="job">Le r�le pour lequel obtenir la liste des employ�s actuellement en poste (par exemple, "Administratif", "Enseignant").</param>
    /// <returns>Une liste d'objets <c>EmployeeData</c> correspondant aux employ�s actuellement en poste pour ce r�le.</returns>
    public List<EmployeeData> GetEmployeeList(string job)
    {
        switch (job)
        {
            case "Administratif":
                return adminEmployees;
            case "Enseignant":
                return teacherEmployees;
            case "Entretient":
                return maintenanceEmployees;
            case "Informatique":
                return itEmployees;
            default:
                return new List<EmployeeData>();
        }
    }

    /// <summary>
    /// Embauche un employ� pour un poste sp�cifique.
    /// </summary>
    /// <param name="job">Le r�le pour lequel embaucher l'employ� (par exemple, "Administratif", "Enseignant").</param>
    /// <param name="employeeData">Les donn�es de l'employ� � embaucher.</param>
    public void HireEmployee(string job, EmployeeData employeeData)
    {
        List<EmployeeData> recruitmentList = GetRecruitmentList(job);
        List<EmployeeData> employeeList = GetEmployeeList(job);

        if (recruitmentList.Contains(employeeData))
        {
            recruitmentList.Remove(employeeData);
            employeeList.Add(employeeData);
        }
    }

    /// <summary>
    /// Retourne la liste de tous les employ�s, peu importe leur poste.
    /// </summary>
    /// <returns>Une liste de tous les employ�s enregistr�s.</returns>
    public List<EmployeeData> GetAllEmployees()
    {
        return adminEmployees
            .Concat(teacherEmployees)
            .Concat(maintenanceEmployees)
            .Concat(itEmployees)
            .ToList();
    }

    /// <summary>
    /// Licencie un employ� d'un poste sp�cifique.
    /// </summary>
    /// <param name="job">Le r�le de l'employ� � licencier (par exemple, "Administratif", "Enseignant").</param>
    /// <param name="employeeData">Les donn�es de l'employ� � licencier.</param>
    public void FireEmployee(string job, EmployeeData employeeData)
    {
        if (job == "Administratif")
        {
            adminEmployees.Remove(employeeData);
        }
        else if (job == "Enseignant")
        {
            teacherEmployees.Remove(employeeData);
        }
        else if (job == "Entretient")
        {
            maintenanceEmployees.Remove(employeeData);
        }
        else if (job == "Informatique")
        {
            itEmployees.Remove(employeeData);
        }
        if (CrisisManager.Instance != null)
        {
            CrisisManager.Instance.RemoveFromConflicts(employeeData);
        }
    }

    /// <summary>
    /// Augmente l'efficacit� au travail d'un employ� sp�cifique pour son r�le.
    /// </summary>
    /// <param name="augm">L'augmentation de l'efficacit� au travail de l'employ� (peut �tre n�gatif ou positif).</param>
    /// <param name="empModif">Les donn�es de l'employ� � modifier (l'employ� dont l'efficacit� au travail est augment�e).</param>
    public void moreWorkEfficiency(float augm, EmployeeData empModif)
    {
        switch (empModif.job)
        {
            case "Administratif":
                foreach (EmployeeData emp in adminEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workEfficiencyGrade = empModif.workEfficiencyGrade + augm > maxGrade ? maxGrade : empModif.workEfficiencyGrade + augm;
                        break;
                    }
                }
                break;
            case "Enseignant":
                foreach (EmployeeData emp in teacherEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workEfficiencyGrade = empModif.workEfficiencyGrade + augm > maxGrade ? maxGrade : empModif.workEfficiencyGrade + augm;
                        break;
                    }
                }
                break;
            case "Entretient":
                foreach (EmployeeData emp in maintenanceEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workEfficiencyGrade = empModif.workEfficiencyGrade + augm > maxGrade ? maxGrade : empModif.workEfficiencyGrade + augm;
                        break;
                    }
                }
                break;
            case "Informatique":
                foreach (EmployeeData emp in itEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workEfficiencyGrade = empModif.workEfficiencyGrade + augm > maxGrade ? maxGrade : empModif.workEfficiencyGrade + augm;
                        break;
                    }
                }
                break;
        }
    }

    /// <summary>
    /// Augmente la coh�sion au travail d'un employ� sp�cifique pour son r�le.
    /// </summary>
    /// <param name="augm">L'augmentation de l'efficacit� au travail de l'employ� (peut �tre n�gatif ou positif).</param>
    /// <param name="empModif">Les donn�es de l'employ� � modifier.</param>
    public void moreTeamEfficiency(float augm, EmployeeData empModif)
    {
        switch (empModif.job)
        {
            case "Administratif":
                foreach (EmployeeData emp in adminEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workTeamGrade = empModif.workTeamGrade + augm > maxGrade ? maxGrade : empModif.workTeamGrade + augm;
                        break;
                    }
                }
                break;
            case "Enseignant":
                foreach (EmployeeData emp in teacherEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workTeamGrade = empModif.workTeamGrade + augm > maxGrade ? maxGrade : empModif.workTeamGrade + augm;
                        break;
                    }
                }
                break;
            case "Entretient":
                foreach (EmployeeData emp in maintenanceEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workTeamGrade = empModif.workTeamGrade + augm > maxGrade ? maxGrade : empModif.workTeamGrade + augm;
                        break;
                    }
                }
                break;
            case "Informatique":
                foreach (EmployeeData emp in itEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.workTeamGrade = empModif.workTeamGrade + augm > maxGrade ? maxGrade : empModif.workTeamGrade + augm;
                        break;
                    }
                }
                break;
        }
    }

    /// <summary>
    /// Augmente la fid�lit� d'un employ� sp�cifique.
    /// </summary>
    /// <param name="prime">L'augmentation d'argent que l'employ� va recevoir).</param>
    /// <param name="empModif">Les donn�es de l'employ� � modifier.</param>
    public void addPrime(float prime, EmployeeData empModif)
    {
        switch (empModif.job)
        {
            case "Administratif":
                foreach (EmployeeData emp in adminEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.fidelityGrade = empModif.fidelityGrade + prime > maxGrade ? maxGrade : empModif.fidelityGrade + prime;
                        break;
                    }
                }
                break;
            case "Enseignant":
                foreach (EmployeeData emp in teacherEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.fidelityGrade = empModif.fidelityGrade + prime > maxGrade ? maxGrade : empModif.fidelityGrade + prime;
                        break;
                    }
                }
                break;
            case "Entretient":
                foreach (EmployeeData emp in maintenanceEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.fidelityGrade = empModif.fidelityGrade + prime > maxGrade ? maxGrade : empModif.fidelityGrade + prime;
                        break;
                    }
                }
                break;
            case "Informatique":
                foreach (EmployeeData emp in itEmployees)
                {
                    if (emp == empModif)
                    {
                        emp.fidelityGrade = empModif.fidelityGrade + prime > maxGrade ? maxGrade : empModif.fidelityGrade + prime;
                        break;
                    }
                }
                break;
        }
        if (CrisisManager.Instance != null)
        {
            CrisisManager.Instance.RemoveFromConflicts(empModif);
        }
    }

    /// <summary>
    /// Calcule l'efficacit� d'un b�timent sp�cifique en fonction des performances des employ�s et des facteurs externes.
    /// </summary>
    /// <param name="buildingName">Le nom du b�timent pour lequel calculer l'efficacit�.</param>
    /// <returns>L'efficacit� calcul�e du b�timent sp�cifi�.</returns>
    public float CalculateBuildingEfficiency(string buildingName)
    {
        List<EmployeeData> employees = GetEmployeeList(buildingName);
        BuildingEfficiency buildingEfficiency = buildingEfficiencies.Find(b => b.buildingName == buildingName);

        if (buildingEfficiency == null)
        {
            return 0;
        }

        int buildingIndex = GetBuildingIndexByName(buildingName);
        if (CrisisManager.Instance != null && (CrisisManager.Instance.GetBuildingState(buildingIndex) || CrisisManager.Instance.GetBuildingHackedState(buildingIndex)))
        {
            return -8;
        }

        if (employees.Count == 0)
        {
            return -25;
        }

        float totalEfficiency = 0;

        foreach (EmployeeData employee in employees)
        {
            if (!employee.onStrike)
            {
                totalEfficiency += (employee.workEfficiencyGrade * buildingEfficiency.workEfficiencyCoefficient) +
                                    (employee.workTeamGrade * buildingEfficiency.teamEfficiencyCoefficient);
            }
        }
        totalEfficiency = (totalEfficiency - 8)-ResourceManager.Instance.CurrentTurn*1.3f;
        if (totalEfficiency <= 0)
        {
            return totalEfficiency;
        }
        else
        {
            return (totalEfficiency / buildingEfficiency.nbEmployeeMeta) * 2;
        }
    }

    /// <summary>
    /// Calcule le salaire total de tous les employ�s en multipliant leur salaire mensuel par 6 (pour obtenir un salaire sur 6 mois).
    /// </summary>
    /// <returns>Le salaire total de tous les employ�s pour 6 mois.</returns>
    public float CalculateTotalSalaries()
    {
        float totalSalaries = 0;

        foreach (EmployeeData employee in GetAllEmployees())
        {
            totalSalaries += employee.salary * 6;
        }

        return totalSalaries;
    }

    /// <summary>
    /// D�marre une gr�ve dans un b�timent sp�cifique en affectant un certain nombre d'employ�s � la gr�ve.
    /// </summary>
    /// <param name="buildingIndex">L'indice du b�timent o� la gr�ve doit commencer. L'indice d�termine la liste des employ�s concern�s.</param>
    /// <param name="numberOfStrikers">Le nombre d'employ�s qui doivent participer � la gr�ve.</param>
    public void StartStrike(int buildingIndex, int numberOfStrikers)
    {
        List<EmployeeData> employees = GetEmployeeListByBuildingIndex(buildingIndex);
        if (employees != null && employees.Count > 0)
        {
            List<int> randomIndices = GenerateRandomIndices(employees.Count, numberOfStrikers);

            foreach (int index in randomIndices)
            {
                employees[index].onStrike = true;
            }
            Debug.Log("Started strike in building " + buildingIndex + " with " + numberOfStrikers + " strikers.");
        }
    }

    /// <summary>
    /// Termine la gr�ve dans un b�timent sp�cifique en r�initialisant le statut de gr�ve de tous les employ�s.
    /// </summary>
    /// <param name="buildingIndex">L'indice du b�timent o� la gr�ve doit �tre termin�e. Cela d�termine les employ�s � r�initialiser.</param>
    public void EndStrike(int buildingIndex)
    {
        List<EmployeeData> employees = GetEmployeeListByBuildingIndex(buildingIndex);
        if (employees != null)
        {
            foreach (EmployeeData employee in employees)
            {
                employee.onStrike = false;
            }
            Debug.Log("Ended strike in building " + buildingIndex);
        }
    }

    /// <summary>
    /// Obtient la liste des employ�s affect�s � un b�timent en fonction de son indice.
    /// </summary>
    /// <param name="buildingIndex">L'indice du b�timent dont on veut obtenir les employ�s.</param>
    /// <returns>Une liste d'employ�s affect�s au b�timent sp�cifi�.</returns>
    public List<EmployeeData> GetEmployeeListByBuildingIndex(int buildingIndex)
    {
        switch (buildingIndex)
        {
            case 1: return itEmployees;
            case 2: return teacherEmployees;
            case 3: return adminEmployees;
            case 4: return maintenanceEmployees;
            default: return new List<EmployeeData>();
        }
    }

    /// <summary>
    /// G�n�re une liste d'indices al�atoires sans r�p�tition, utilis�e pour s�lectionner des employ�s pour une gr�ve.
    /// </summary>
    /// <param name="count">Le nombre total d'employ�s dans la liste.</param>
    /// <param name="numberOfIndices">Le nombre d'indices � g�n�rer (c'est-�-dire, le nombre de gr�vistes).</param>
    /// <returns>Une liste d'indices uniques repr�sentant les employ�s qui seront affect�s � la gr�ve.</returns>
    private List<int> GenerateRandomIndices(int count, int numberOfIndices)
    {
        List<int> indices = new List<int>();
        HashSet<int> usedIndices = new HashSet<int>();

        while (indices.Count < numberOfIndices)
        {
            int randomIndex = UnityEngine.Random.Range(0, count);
            if (!usedIndices.Contains(randomIndex))
            {
                indices.Add(randomIndex);
                usedIndices.Add(randomIndex);
            }
        }

        return indices;
    }

    /// <summary>
    /// Obtient la liste des employ�s en gr�ve dans un b�timent sp�cifique.
    /// </summary>
    /// <param name="buildingIndex">L'indice du b�timent pour lequel on veut obtenir les employ�s en gr�ve.</param>
    /// <returns>Une liste des employ�s en gr�ve dans le b�timent sp�cifi�.</returns>
    public List<EmployeeData> GetStrikingEmployees(int buildingIndex)
    {
        List<EmployeeData> employees = GetEmployeeListByBuildingIndex(buildingIndex);

        return employees.Where(employee => employee.onStrike).ToList();
    }

    /// <summary>
    /// Diminue la fid�lit� des employ�s et renvoie ceux dont la fid�lit� est inf�rieure � un seuil pour les renvoyer.
    /// </summary>
    public void DecreaseFidelity()
    {
        foreach (var kvp in resignedEmployees)
        {
            kvp.Value.Clear();
        }

        List<EmployeeData> tempAdminEmployees = new List<EmployeeData>(adminEmployees);
        List<EmployeeData> tempTeacherEmployees = new List<EmployeeData>(teacherEmployees);
        List<EmployeeData> tempMaintenanceEmployees = new List<EmployeeData>(maintenanceEmployees);
        List<EmployeeData> tempItEmployees = new List<EmployeeData>(itEmployees);

        foreach (var employee in tempAdminEmployees)
        {
            employee.fidelityGrade = Mathf.Clamp(employee.fidelityGrade - UnityEngine.Random.Range(0f, 1.2f), 0, maxGrade);
            if (employee.fidelityGrade < 1)
            {
                FireEmployee("Administratif", employee);
                AddToResignedList(employee, "Administratif");
            }
        }

        foreach (var employee in tempTeacherEmployees)
        {
            employee.fidelityGrade = Mathf.Clamp(employee.fidelityGrade - UnityEngine.Random.Range(0f, 0.5f), 0, maxGrade);
            if (employee.fidelityGrade < 1)
            {
                FireEmployee("Enseignant", employee);
                AddToResignedList(employee, "Enseignant");
            }
        }

        foreach (var employee in tempMaintenanceEmployees)
        {
            employee.fidelityGrade = Mathf.Clamp(employee.fidelityGrade - UnityEngine.Random.Range(0f, 0.5f), 0, maxGrade);
            if (employee.fidelityGrade < 1)
            {
                FireEmployee("Entretient", employee);
                AddToResignedList(employee, "Entretient");
            }
        }

        foreach (var employee in tempItEmployees)
        {
            employee.fidelityGrade = Mathf.Clamp(employee.fidelityGrade - UnityEngine.Random.Range(0f, 0.5f), 0, maxGrade);
            if (employee.fidelityGrade < 1)
            {
                FireEmployee("Informatique", employee);
                AddToResignedList(employee, "Informatique");
            }
        }
    }

    private Dictionary<string, List<EmployeeData>> resignedEmployees = new Dictionary<string, List<EmployeeData>>
    {
        { "Administratif", new List<EmployeeData>() },
        { "Enseignant", new List<EmployeeData>() },
        { "Entretient", new List<EmployeeData>() },
        { "Informatique", new List<EmployeeData>() }
    };

    public Dictionary<string, List<EmployeeData>> GetResignedEmployees()
    {
        return resignedEmployees;
    }

    /// <summary>
    /// Ajoute un employ� � la liste des employ�s d�missionnaires pour un r�le sp�cifique.
    /// </summary>
    /// <param name="employee">L'employ� � ajouter � la liste des d�missionnaires.</param>
    /// <param name="job">Le r�le de l'employ� qui a d�missionn� (par exemple, "Administratif", "Enseignant").</param>
    private void AddToResignedList(EmployeeData employee, string job)
    {
        if (resignedEmployees.ContainsKey(job))
        {
            resignedEmployees[job].Add(employee);
        }
        else
        {
            resignedEmployees[job] = new List<EmployeeData> { employee };
        }
    }

    /// <summary>
    /// Affiche les employ�s ayant d�missionn� pour chaque r�le dans la console de d�bogage.
    /// </summary>
    public void DisplayResignedEmployees()
    {
        foreach (var kvp in resignedEmployees)
        {
            Debug.Log("Resigned Employees in " + kvp.Key + ":");
            foreach (var employee in kvp.Value)
            {
                Debug.Log("Resigned Employee: " + employee.GetFirstName() + " " + employee.GetLastName());
            }
        }
    }

    /// <summary>
    ///R�cup�re l'indice du batiment grace au nom.
    /// </summary>
    private int GetBuildingIndexByName(string buildingName)
    {
        switch (buildingName)
        {
            case "Entretient":
                return 3;
            case "Enseignant":
                return 2;
            case "Administratif":
                return 4;
            case "Informatique":
                return 1;
            default:
                return -1;
        }
    }

    /// <summary>
    /// R�initialise les listes des employ�s, des employ�s d�missionnaires et des coefficients d'efficacit� des b�timents.
    /// </summary>
    public void ResetEmployees()
    {
        adminEmployees.Clear();
        teacherEmployees.Clear();
        maintenanceEmployees.Clear();
        itEmployees.Clear();
        adminRecruitmentList.Clear();
        teacherRecruitmentList.Clear();
        maintenanceRecruitmentList.Clear();
        itRecruitmentList.Clear();
        resignedEmployees.Clear();
        resignedEmployees = new Dictionary<string, List<EmployeeData>>
        {
            { "Administratif", new List<EmployeeData>() },
            { "Enseignant", new List<EmployeeData>() },
            { "Entretient", new List<EmployeeData>() },
            { "Informatique", new List<EmployeeData>() }
        };
        buildingEfficiencies.Clear();
        buildingEfficiencies = new List<BuildingEfficiency>
        {
            new BuildingEfficiency { buildingName = "Administratif", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.8f, nbEmployeeMeta = 4 },
            new BuildingEfficiency { buildingName = "Enseignant", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.7f, nbEmployeeMeta = 6 },
            new BuildingEfficiency { buildingName = "Entretient", workEfficiencyCoefficient = 0.4f, teamEfficiencyCoefficient = 0.6f, nbEmployeeMeta = 3},
            new BuildingEfficiency { buildingName = "Informatique", workEfficiencyCoefficient = 0.7f, teamEfficiencyCoefficient = 0.4f, nbEmployeeMeta = 4 }
        };

    }

    public void ClearAllRecruitmentLists()
    {
        adminRecruitmentList.Clear();
        teacherRecruitmentList.Clear();
        maintenanceRecruitmentList.Clear();
        itRecruitmentList.Clear();
    }
}