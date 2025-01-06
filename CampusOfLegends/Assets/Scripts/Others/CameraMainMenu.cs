using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette classe g�re le mouvement de la cam�ra autour d'une cible dans le menu principal.
/// La cam�ra effectue une rotation circulaire autour de la cible � une vitesse constante.
/// </summary>
public class CameraMainMenu : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 0.1f;
    public float radius = 25f;
    public float height = 25f;
    public float initialAngleOffset = Mathf.PI / 2; // Ajout d'un d�calage initial de 90 degr�s (PI/2 radians)

    /// <summary>
    /// Mise � jour de la position de la cam�ra � chaque frame.
    /// Cette m�thode fait tourner la cam�ra autour de la cible selon un mouvement circulaire.
    /// </summary>
    private void Update()
    {
        if (target != null)
        {
            // Calculer l'angle de rotation en fonction du temps �coul�
            float angle = Time.time * rotationSpeed + initialAngleOffset * 3;

            // Calculer la position de la cam�ra en fonction de l'angle et du rayon
            float x = target.position.x + radius * Mathf.Cos(angle);
            float z = target.position.z + radius * Mathf.Sin(angle);
            float y = target.position.y + height;

            // D�finir la position de la cam�ra
            transform.position = new Vector3(x, y, z);

            // Faire en sorte que la cam�ra regarde toujours la cible
            transform.LookAt(target);
        }
    }
}
