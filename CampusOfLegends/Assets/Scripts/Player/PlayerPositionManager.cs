using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Cette classe g�re la position du joueur dans le jeu. Elle d�termine o� le joueur appara�t
/// lorsqu'il change de sc�ne en fonction du dernier b�timent visit�. Elle fournit �galement des m�thodes
/// pour activer et d�sactiver le joueur et pour g�rer les points d'entr�e associ�s aux diff�rents b�timents.
/// </summary>
public class PlayerPositionManager : MonoBehaviour
{
    public int lastBuildingIndex = 0;
    public Transform player;

    // Points d'entr�e
    public Transform posBase;
    public Transform entryInfo;
    public Transform entryEns;
    public Transform entryAdmin;
    public Transform entryEntr;
    public Transform entryAccueil;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        HandlePlayerPosition();
    }
    /// <summary>
    /// Inscrit les m�thodes qui s'ex�cutent lorsque la sc�ne est charg�e.
    /// </summary>
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    /// <summary>
    /// D�sinscrit les m�thodes lorsqu'elles ne sont plus n�cessaires.
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    /// <summary>
    /// Cette m�thode est appel�e apr�s chaque chargement de sc�ne. Elle v�rifie
    /// la sc�ne courante et prend les actions n�cessaires (d�sactiver ou activer le joueur, etc.).
    /// </summary>
    /// <param name="scene">La sc�ne qui a �t� charg�e.</param>
    /// <param name="mode">Le mode de chargement de la sc�ne.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "transitionSemester")
        {
            DisablePlayer();
            FireManager.Instance.EnableFires();

        }
        else if (scene.name == "mapV3")
        {
            HandlePlayerPosition();
            FireManager.Instance.EnableFires();
        }
    }
    /// <summary>
    /// G�re la position du joueur en fonction du dernier b�timent index�.
    /// </summary>
    public void HandlePlayerPosition()
    {
        if (lastBuildingIndex != -1)
        {
            Transform entryPoint = GetEntryPoint(lastBuildingIndex);
            if (entryPoint != null && player != null)
            {
                player.position = entryPoint.position;
                player.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// D�finit l'index du dernier b�timent dans lequel le joueur s'est trouv�.
    /// </summary>
    /// <param name="index">L'index du b�timent.</param>
    public void SetLastBuildingIndex(int index)
    {
        lastBuildingIndex = index;
    }


    /// <summary>
    /// Retourne le point d'entr�e associ� � un b�timent donn�.
    /// </summary>
    /// <param name="buildingIndex">L'index du b�timent.</param>
    /// <returns>Le transform du point d'entr�e du b�timent sp�cifi�.</returns>
    public Transform GetEntryPoint(int buildingIndex)
    {
        switch (buildingIndex)
        {
            case 0: return posBase;
            case 1: return entryInfo;
            case 2: return entryEns;
            case 3: return entryAdmin;
            case 4: return entryEntr;
            case 5: return entryAccueil;
            default:
                return null;
        }
    }


    /// <summary>
    /// D�sactive le joueur (r�initialise la position et l'�tat du joueur).
    /// </summary>
    public void DisablePlayer()
    {
        if (player != null)
        {
            player.GetComponent<PlayerController>().ResetTargetPosition();
            player.gameObject.SetActive(false);
            FireManager.Instance.DisableFires();
        }
    }

    /// <summary>
    /// R�initialise la position du joueur au point d'entr�e de base.
    /// </summary>
    public void ResetPosition()
    {
        SetLastBuildingIndex(0);

    }
}
