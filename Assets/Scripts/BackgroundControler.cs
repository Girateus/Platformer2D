using UnityEngine;

public class BackgroundControler : MonoBehaviour
{
    private Vector2 _startPos;

    public GameObject _cam;
    public float ParallaxEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
       
        float distanceX = _cam.transform.position.x * ParallaxEffect;
        float distanceY = _cam.transform.position.y * ParallaxEffect;

        
        transform.position = new Vector3(_startPos.x + distanceX, _startPos.y + distanceY, transform.position.z);
    }
}
