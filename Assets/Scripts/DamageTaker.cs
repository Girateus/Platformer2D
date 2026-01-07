using UnityEngine;
using UnityEngine.Events;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] private float _hpMax;
    [SerializeField] private UnityEvent _onDeath;
    [SerializeField] private bool _destroyable = true;
    [SerializeField] private UnityEvent _gameOver;
    public UnityEvent<float> OnHealthChanged = new UnityEvent<float>();
    public float HpMax => _hpMax;
    
    public float _hp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hp = _hpMax;
        OnHealthChanged.Invoke(_hp);
        
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        _hp -= damage;
        OnHealthChanged.Invoke(_hp);

        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        _onDeath.Invoke();
        /*if (_destroyable)
        {
            _gameOver.Invoke();
           //Destroy(gameObject);
        }*/
    }
    
}