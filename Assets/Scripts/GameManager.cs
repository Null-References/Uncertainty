using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public Transform GetPlayerTransform() => playerTransform;

    public void SaveThis<T>(T thing, string saveName) => SavingLoadingData.Save(thing, saveName);

    public T LoadThis<T>(string saveName) => SavingLoadingData.Load<T>(saveName);
}