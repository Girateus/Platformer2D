using UnityEngine;

public class Potions : MonoBehaviour
{
    private DamageTaker _heal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Heal !");
            
            DamageTaker PlayerHealth = other.GetComponent<DamageTaker>();
        
            if (PlayerHealth != null)
            {
                PlayerHealth.Heal(5f);
                Destroy(gameObject);
            }
        }  
    }
}
