using System;
using UnityEngine;

/// <summary>
/// Classe repr�sentant un employ� dans le jeu, avec ses caract�ristiques personnelles et professionnelles.
/// </summary>
[Serializable]
public class Employee : MonoBehaviour
{
    private string firstName;
    private string lastName;
    private string job;
    private int salary;
    private int age;
    private float workEfficiencyGrade;
    private float workTeamGrade;
    private float fidelityGrade;
    private char sexe;
    private GameObject prefab;
    private bool onStrike;

    /// <summary>
    /// D�finit les informations de l'employ�.
    /// </summary>
    /// <param name="firstName">Pr�nom de l'employ�.</param>
    /// <param name="lastName">Nom de famille de l'employ�.</param>
    /// <param name="job">Poste occup� par l'employ�.</param>
    /// <param name="salary">Salaire mensuel de l'employ�.</param>
    /// <param name="age">�ge de l'employ�.</param>
    /// <param name="workEfficiencyGrade">Note d'efficacit� au travail (de 0 � 10).</param>
    /// <param name="workTeamGrade">Note de travail en �quipe (de 0 � 10).</param>
    /// <param name="sexe">Sexe de l'employ� ('M', 'F', etc.).</param>
    /// <param name="fidelityGrade">Note de fid�lit� (de 0 � 10).</param>
    /// <param name="onStrike">Indique si l'employ� est en gr�ve.</param>
    public void SetEmployee(string firstName, string lastName, string job, int salary, int age, float workEfficiencyGrade, float workTeamGrade, char sexe, float fidelityGrade, bool onStrike)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.job = job;
        this.salary = salary;
        this.age = age;
        this.workEfficiencyGrade = workEfficiencyGrade;
        this.workTeamGrade = workTeamGrade;
        this.sexe = sexe;
        this.fidelityGrade = fidelityGrade;
        this.onStrike = onStrike;
    }
    /// <summary>
    /// D�finit les informations de l'employ� avec un prefab associ�.
    /// </summary>
    /// <param name="firstName">Pr�nom de l'employ�.</param>
    /// <param name="lastName">Nom de famille de l'employ�.</param>
    /// <param name="job">Poste occup� par l'employ�.</param>
    /// <param name="salary">Salaire mensuel de l'employ�.</param>
    /// <param name="age">�ge de l'employ�.</param>
    /// <param name="workEfficiencyGrade">Note d'efficacit� au travail (de 0 � 10).</param>
    /// <param name="workTeamGrade">Note de travail en �quipe (de 0 � 10).</param>
    /// <param name="sexe">Sexe de l'employ� ('M', 'F', etc.).</param>
    /// <param name="prefabAj">Prefab associ� � l'employ�.</param>
    /// <param name="fidelityGrade">Note de fid�lit� (de 0 � 10).</param>
    /// <param name="onStrike">Indique si l'employ� est en gr�ve.</param>
    public void SetEmployee(string firstName, string lastName, string job, int salary, int age, float workEfficiencyGrade, float workTeamGrade, char sexe, GameObject prefabAj, float fidelityGrade, bool onStrike)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.job = job;
        this.salary = salary;
        this.age = age;
        this.workEfficiencyGrade = workEfficiencyGrade;
        this.workTeamGrade = workTeamGrade;
        this.sexe = sexe;
        this.prefab = prefabAj;
        this.fidelityGrade = fidelityGrade;
        this.onStrike = onStrike;
    }

    public string GetFirstname()
    {
        return firstName;
    }

    public string GetLastname()
    {
        return lastName;
    }

    public int GetSalary()
    {
        return salary;
    }

    public int GetAge()
    {
        return age;
    }

    public float GetWorkEfficiencyGrade()
    {
        return workEfficiencyGrade;
    }

    public float GetWorkTeamGrade()
    {
        return workTeamGrade;
    }

    public float GetFidelityGrade()
    {
        return fidelityGrade;
    }

    public bool GetOnStrike()
    {
        return onStrike;
    }
    /// <summary>
    /// Convertit les informations de l'employ� en un objet `EmployeeData` s�rialisable.
    /// </summary>
    /// <returns>Un objet <see cref="EmployeeData"/> contenant les donn�es de l'employ�.</returns>
    public EmployeeData ToEmployeeData()
    {
        return new EmployeeData(firstName, lastName, job, salary, age, workEfficiencyGrade, workTeamGrade, sexe, prefab, fidelityGrade, onStrike);
    }
    /// <summary>
    /// Remplit les informations de l'employ� � partir d'un objet `EmployeeData`.
    /// </summary>
    /// <param name="data">Les donn�es de l'employ�.</param>
    public void FromEmployeeData(EmployeeData data)
    {
        SetEmployee(data.firstName, data.lastName, data.job, data.salary, data.age, data.workEfficiencyGrade, data.workTeamGrade, data.sexe, data.prefab, data.fidelityGrade, data.onStrike);
    }
}
