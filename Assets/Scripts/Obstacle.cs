using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
