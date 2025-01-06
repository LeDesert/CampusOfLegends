using UnityEngine;

/// <summary>
/// Le gestionnaire des hacks dans le jeu. Il g�re l'affichage des effets visuels pour les b�timents hack�s.
/// Ce script permet d'activer ou de d�sactiver l'affichage des hacks sur les b�timents, en fonction de l'�tat de chaque b�timent.
/// </summary>
public class HackManager : MonoBehaviour
{
    public static HackManager Instance { get; private set; }
    private GameObject[] hackObjects;
    public static SettingsManager Instance2 { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hackObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            hackObjects[i] = transform.GetChild(i).gameObject;
        }

        UpdateHackDisplay();
    }

    /// <summary>
    /// Met � jour l'affichage des hacks en fonction de l'�tat des b�timents (hack�s ou non).
    /// </summary>
    public void UpdateHackDisplay()
    {
        if (hackObjects != null)
        {
            for (int i = 0; i < hackObjects.Length; i++)
            {
                // V�rifie si le b�timent est hack�
                bool isClosed = CrisisManager.Instance.GetBuildingHackedState(i + 1);
                hackObjects[i].SetActive(isClosed);
                if(isClosed)
                {
                    //SettingsManager.Instance.SoundsSource.Add(hackObjects[i].GetComponent<AudioSource>());
                    //hackObjects[i].GetComponent<AudioSource>().volume = SettingsManager.Instance.SoundVolume;
                }
            }
        }
    }

    /// <summary>
    /// D�sactive tous les hacks (cache les objets de hack).
    /// </summary>
    public void DisableHack()
    {
        if (hackObjects != null)
        {
            foreach (GameObject hack in hackObjects)
            {
                hack.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Active tous les hacks (affiche les objets de hack en fonction de l'�tat des b�timents).
    /// </summary>
    public void EnableHack()
    {
        if (hackObjects != null)
        {
            for (int i = 0; i < hackObjects.Length; i++)
            {
                // V�rifie l'�tat du b�timent et active ou d�sactive le hack en cons�quence
                bool isClosed = CrisisManager.Instance.GetBuildingHackedState(i + 1);
                hackObjects[i].SetActive(isClosed);
            }
        }
    }
}
