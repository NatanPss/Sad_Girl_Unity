using System.ComponentModel.Design;
using UnityEngine;

public class InvocatorScrip : MonoBehaviour
{
    [Header("Armadilha")]
    public GameObject prefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    [Header("Moviment")]
    public float speed = 5f;
    public float SumRunSpeed = 0.2f;

    [Header("Score")]
    public float pontuation =0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate(Vector2.x * speed * Time.deltaTime, Space.World);
        //if (pontuation >= nextSpeedScore) {
        //    speed += SumRunSpeed;
        //    nextSpeedScore += 10;
        //}
        
    }


}
