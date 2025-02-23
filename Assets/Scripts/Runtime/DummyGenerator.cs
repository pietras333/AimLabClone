using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGenerator : MonoBehaviour
{
    public static DummyGenerator Instance { get; private set; }

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Transform canvas;

    [SerializeField]
    private float spawnInterval = 1f;

    [SerializeField]
    private GameObject dummyPrefab;

    [SerializeField]
    private BoxCollider spawnArea;

    [SerializeField]
    private float workTime = 10f;

    private float timer = 0f;
    public bool isWorking = true;

    private void Start()
    {
        playerController.SetCursorActivity(true);
        canvas.gameObject.SetActive(true);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!isWorking)
        {
            return;
        }
        if (workTime <= 0f)
        {
            isWorking = false;
            playerController.SetCursorActivity(true);
            canvas.gameObject.SetActive(true);

            ScoreManager.Instance.GameOver();
        }

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnDummy();
        }

        workTime -= Time.deltaTime;
    }

    public void Play()
    {
        Debug.Log("Playing game");
        isWorking = true;
    }

    public void PrepareForGame()
    {
        workTime = 10f;
        timer = 0f;
        canvas.gameObject.SetActive(false);
        playerController.SetCursorActivity(false);
    }

    private void SpawnDummy()
    {
        Vector3 spawnPosition =
            new(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

        GameObject dummy = Instantiate(dummyPrefab, spawnPosition, Quaternion.identity);

        dummy.transform.localScale = Vector3.one * Random.Range(0.5f, 2f);
    }
}
