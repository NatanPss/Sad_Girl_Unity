using UnityEngine;

public class Obstacle:MonoBehaviour
{
    private float leftBound;

    private void Start()
    {
        leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x-2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManage.Instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }
}
