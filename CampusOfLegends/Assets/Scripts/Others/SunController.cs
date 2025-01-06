using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    /// <summary>
    /// Cette classe contr�le la simulation du mouvement du soleil dans la sc�ne en fonction du temps.
    /// Le soleil suit une trajectoire circulaire autour du centre de la sc�ne, avec un mouvement continu, et ajuste
    /// l'intensit� et la couleur de la lumi�re directionnelle pour simuler les variations de la lumi�re en fonction de l'heure de la journ�e.
    /// </summary>
    /// 
    public float rotationSpeed = 0.1f; // Vitesse de rotation du soleil
    public float radius = 100f; // Rayon de l'orbite du soleil
    public float height = 50f; // Hauteur du soleil par rapport au centre de la sc�ne
    public Vector3 center = Vector3.zero; // Centre de la sc�ne
    public Light sunLight; // R�f�rence � la lumi�re directionnelle


    /// <summary>
    /// M�thode appel�e � chaque frame pour mettre � jour la position du soleil et ajuster l'intensit� de la lumi�re.
    /// Le soleil se d�place en fonction du temps, et l'intensit� ainsi que la couleur de la lumi�re directionnelle
    /// sont ajust�es pour simuler les changements de lumi�re pendant la journ�e.
    /// </summary>
    private void Update()
    {
        // Calculer l'angle de rotation en fonction du temps �coul�
        float angle = Time.time * rotationSpeed;

        // Calculer la position du soleil en fonction de l'angle et du rayon
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);
        float y = center.y + height;

        // D�finir la position du soleil
        transform.position = new Vector3(x, y, z);

        // Faire en sorte que le soleil regarde toujours le centre de la sc�ne
        transform.LookAt(center);

        // Ajuster l'intensit� et la couleur de la lumi�re en fonction de l'angle de rotation
        float intensity = Mathf.Clamp01(Mathf.Pow(Mathf.Sin(angle), 2f)); // Utiliser une fonction non lin�aire pour ajuster l'intensit�
        sunLight.intensity = intensity;

        // Ajuster la couleur de la lumi�re pour simuler une belle journ�e ensoleill�e
        if (intensity > 0.5f)
        {
            // Journ�e ensoleill�e
            sunLight.color = Color.Lerp(new Color(1f, 0.95f, 0.8f), Color.white, (intensity - 0.5f) * 2f);
        }
        else
        {
            // Lever/coucher du soleil
            sunLight.color = Color.Lerp(new Color(1f, 0.5f, 0f), new Color(1f, 0.95f, 0.8f), intensity * 2f);
        }
    }
}