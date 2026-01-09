using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.UpdateSpawnPoint(this.transform);
            // Optionnel : Désactiver le trigger pour ne pas l'activer 100 fois
            GetComponent<Collider2D>().enabled = false;
        }
    }
}