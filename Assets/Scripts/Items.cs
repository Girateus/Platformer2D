using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private SO_Items _itemDatas;
    AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerStats stats))
        {
            audioManager.PlaySound(audioManager.CoinSound);
            stats.MakeMoney(_itemDatas.GoldCoin);
            Destroy(gameObject);
        }
    }
}
