using System;
using UnityEngine;
/// <summary>
/// Classe s�rialisable repr�sentant les donn�es d'un employ�.
/// Contient des informations sur l'identit�, le poste, les performances et l'�tat de l'employ�.
/// </summary>
[Serializable]
public class EmployeeData
{
    public string firstName;
    public string lastName;
    public string job;
    public int salary;
    public int age;
    public float workEfficiencyGrade;
    public float workTeamGrade;
    public float fidelityGrade;
    public char sexe;
    public GameObject prefab;
    public bool onStrike;


    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="EmployeeData"/> avec toutes les propri�t�s.
    /// </summary>
    /// <param name="firstName">Pr�nom de l'employ�.</param>
    /// <param name="lastName">Nom de l'employ�.</param>
    /// <param name="job">Poste occup� par l'employ�.</param>
    /// <param name="salary">Salaire de l'employ�.</param>
    /// <param name="age">�ge de l'employ�.</param>
    /// <param name="workEfficiencyGrade">Note d'efficacit� au travail.</param>
    /// <param name="workTeamGrade">Note de travail en �quipe.</param>
    /// <param name="sexe">Sexe de l'employ�.</param>
    /// <param name="prefab">Prefab associ�.</param>
    /// <param name="fidelityGrade">Note de fid�lit�.</param>
    /// <param name="onStrike">Statut de gr�ve.</param>
    public EmployeeData(string firstName, string lastName, string job, int salary, int age, float workEfficiencyGrade, float workTeamGrade, char sexe, GameObject prefab, float fidelityGrade, bool onStrike)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.job = job;
        this.salary = salary;
        this.age = age;
        this.workEfficiencyGrade = workEfficiencyGrade;
        this.workTeamGrade = workTeamGrade;
        this.sexe = sexe;
        this.prefab = prefab;
        this.fidelityGrade = fidelityGrade;
        this.onStrike = onStrike;
    }

    public string GetFirstName()
    {
        return this.firstName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }

    public string GetJob()
    {
        return this.job;
    }

    public int GetSalary()
    {
        return this.salary;
    }

    public float GetEfficency()
    {
        return this.workEfficiencyGrade;
    }

    public float GetFidelity()
    {
        return this.fidelityGrade;
    }

    public float GetTeam()
    {
        return this.workTeamGrade;
    }

    public GameObject GetPrefab()
    {
        return this.prefab;
    }

    public bool GetOnStrike()
    {
        return this.onStrike;
    }
}
