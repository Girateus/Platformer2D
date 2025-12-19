using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _endGame;
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I'm collided with " + other.gameObject.name);
            _endGame.Invoke();
            Time.timeScale = 0.0f;
        }
       
    }
}

