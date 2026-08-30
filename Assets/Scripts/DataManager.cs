using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public void Awake()
    {
        if (Instance == null)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
