using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill; 
    [SerializeField] private DamageTaker _playerDamageTaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_playerDamageTaker != null)
        {
            _playerDamageTaker.OnHealthChanged.AddListener(UpdateHealthBar);
            UpdateHealthBar(_playerDamageTaker._hp); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthBar(float currentHealth)
    {
        if (_healthBarFill != null && _playerDamageTaker != null)
        {
            float maxHealth = _playerDamageTaker.HpMax;
            
            float healthRatio = currentHealth / maxHealth;
            
            _healthBarFill.fillAmount = healthRatio;
        }
    }
}
