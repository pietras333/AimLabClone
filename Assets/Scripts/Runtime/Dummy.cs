using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField]
    private float timeSinceBirth = 0f;

    [SerializeField]
    private GameObject explosionPrefab;

    void Update()
    {
        timeSinceBirth += Time.deltaTime;
    }

    public float GetScore()
    {
        float scale = transform.localScale.x;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        return (1000 * scale) / timeSinceBirth;
    }
}
