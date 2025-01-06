using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe repr�sentant l'efficacit� d'un b�timent dans le jeu.
/// Elle contient des informations sur l'efficacit� au travail, l'efficacit� de l'�quipe et le nombre d'employ�s dans un b�timent donn�.
/// </summary>
[System.Serializable]
public class BuildingEfficiency
{
    public string buildingName;
    public float workEfficiencyCoefficient;
    public float teamEfficiencyCoefficient;
    public int nbEmployeeMeta;
}