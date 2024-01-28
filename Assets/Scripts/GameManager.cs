using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // public bool IsPaused = false;
    // [SerializeField] private GameObject _UIPrefab;
    [SerializeField] GameObject _audioManagerPrefab;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        InitScene();
    }

    void InitScene()
    {
        Instantiate(_audioManagerPrefab);
    }
}
