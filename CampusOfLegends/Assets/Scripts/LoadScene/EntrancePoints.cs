using UnityEngine;


/// <summary>
/// Cette classe g�re les points d'entr�e pour diff�rents b�timents dans le jeu.
/// Elle permet de r�cup�rer le point d'entr�e sp�cifique en fonction d'un indice de b�timent.
/// Les points d'entr�e sont repr�sent�s par des objets de type Transform, qui sont assign�s dans l'�diteur Unity.
/// </summary>
public class EntrancePoints : MonoBehaviour
{
    public Transform entryInfo;
    public Transform entryEns;
    public Transform entryAdmin;
    public Transform entryEntr;

    /// <summary>
    /// Cette m�thode retourne le point d'entr�e correspondant � l'indice du b�timent pass� en param�tre.
    /// </summary>
    /// <param name="buildingIndex">L'indice du b�timent pour lequel on veut r�cup�rer le point d'entr�e.
    /// L'indice doit �tre 1, 2, 3 ou 4, correspondant � Informatique, Enseignants, Administratif et Entretien respectivement.</param>
    /// <returns>Retourne le Transform du point d'entr�e correspondant ou null si l'indice est invalide.</returns>
    public Transform GetEntryPoint(int buildingIndex)
    {
        Debug.Log("[EntrancePoints] GetEntryPoint called with index: " + buildingIndex);
        switch (buildingIndex)
        {
            case 1: return entryInfo;
            case 2: return entryEns;
            case 3: return entryAdmin;
            case 4: return entryEntr;
            default:
                Debug.LogError("[EntrancePoints] Invalid building index: " + buildingIndex);
                return null;
        }
    }

}