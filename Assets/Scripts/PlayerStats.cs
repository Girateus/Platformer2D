using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private SO_IntValue _gold ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeMoney(int value) => _gold.Value += value;
}
