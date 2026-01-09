using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // Permet d'y accéder de partout
    [SerializeField] private Transform _currentSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSpawnPoint(Transform newPoint)
    {
        _currentSpawnPoint = newPoint;
        Debug.Log("Nouveau Checkpoint activé !");
    }

    public Vector3 GetSpawnPosition()
    {
        return _currentSpawnPoint.position;
    }
}