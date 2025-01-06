using System.Collections.Generic;

/// <summary>
/// Cette classe contient des param�tres statiques qui sont utilis�s pour partager des informations
/// entre les sc�nes, sp�cifiquement pour le trombinoscope.
/// Elle permet de stocker des informations telles que l'appelant de la sc�ne (par exemple, le nom de la sc�ne)
/// et la liste des employ�s � afficher dans le trombinoscope.
/// </summary>
public static class TrombinoParam
{
    /// <summary>
    /// Le nom de la sc�ne appelante, utilis� pour d�terminer d'o� provient la demande pour afficher le trombinoscope.
    /// Ce param�tre peut �tre utilis� pour effectuer des actions sp�cifiques � la sc�ne d'origine.
    /// </summary>
    public static string caller;
    /// <summary>
    /// La liste des employ�s � afficher dans le trombinoscope.
    /// Cette liste est remplie par le gestionnaire d'employ�s et est utilis�e pour afficher les informations des employ�s
    /// dans la sc�ne du trombinoscope.
    /// </summary>
    public static List<EmployeeData> Employees;
}
