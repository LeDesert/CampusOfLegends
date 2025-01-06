using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Contr�leur de cam�ra qui suit une cible donn�e avec un mouvement fluide.
/// G�re un d�calage personnalis� et utilise l'interpolation pour des transitions douces.
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform target;  // Cible que la cam�ra suit
    public float smoothSpeed = 0.125f;  // Vitesse d'interpolation pour le suivi
    public Vector3 offset;  // D�calage de la cam�ra par rapport � la cible

    private void Awake()
    {
        // Calcul de l'offset bas� sur la position initiale de la cam�ra et de la cible
        if (target != null)
        {
            offset = transform.position - target.position;
        }
                
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (target == null)
        {
            return;  // On quitte la m�thode si la cible n'est pas d�finie
        }

        // Position d�sir�e de la cam�ra en fonction de la cible et de l'offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolation de la position de la cam�ra pour un mouvement plus fluide
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Mise � jour de la position de la cam�ra
        transform.position = smoothedPosition;
    }
}
