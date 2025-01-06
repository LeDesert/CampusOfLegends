using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Cette classe est utilis�e pour g�rer l'activation d'un objet dans la sc�ne Unity.
/// Lors du d�marrage, elle v�rifie si l'objet a �t� assign� et l'active.
/// Cela permet de contr�ler la visibilit� ou l'activation d'un objet au d�but du jeu ou lors du chargement d'une sc�ne.
/// </summary>
public class ObjectLoader : MonoBehaviour
{
    public GameObject Object;
    // Start is called before the first frame update
    /// <summary>
    /// M�thode appel�e au d�but du jeu, lors du d�marrage de la sc�ne.
    /// Elle active l'objet si celui-ci a �t� assign�.
    /// </summary>
    void Start()
    {
        if(Object != null)
        {
            Object.gameObject.SetActive(true);

        }
    }


}
