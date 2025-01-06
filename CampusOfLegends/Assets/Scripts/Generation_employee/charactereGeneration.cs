using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class charactereGeneration : MonoBehaviour
{
    private GameObject playerPrefab;
    private void Awake()
    {
        playerPrefab = Resources.Load<GameObject>("Character/Player");
    }

    /// <summary>
    /// Appel� avant la premi�re frame d'update. 
    /// Cette m�thode effectue les actions suivantes :
    /// - Trouve les objets nomm�s "Cube1", "Cube2" et "Cube3" dans la sc�ne.
    /// - Instancie le prefab du joueur s'il a �t� charg� correctement.
    /// - Positionne l'instance du joueur � la position (0, 0, 0).
    /// - Affiche un message dans la console en fonction du succ�s ou de l'�chec du chargement du prefab.
    /// </summary>
    void Start()
    {
        GameObject cube1 = GameObject.Find("Cube1");
        GameObject cube2 = GameObject.Find("Cube2");
        GameObject cube3 = GameObject.Find("Cube3");

        if (playerPrefab != null)
        {
            // Instancier le prefab dans la sc�ne
            GameObject playerInstance = Instantiate(playerPrefab);

            // Positionner l'objet dans la sc�ne
            playerInstance.transform.position = new Vector3(0, 0, 0);

            Debug.Log("Le prefab Player a �t� instanci� avec succ�s !");
        }
        else
        {
            Debug.LogError("Le prefab Player n'a pas �t� trouv� dans Resources/Character !");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
