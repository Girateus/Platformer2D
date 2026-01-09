using UnityEngine;

public class DeathPit : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySound(audioManager.FallSound);
            other.transform.position = LevelManager.Instance.GetSpawnPosition();
        }
    }
}
