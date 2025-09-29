using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float distanceBetweenPipes;
    private float timer;
    private float pipeOffset;
    [SerializeField] private float difficulty;
    private void Start()
    {
        Instantiate(pipePrefab, new Vector3(transform.position.x, returnOffset(), transform.position.z), transform.rotation);


    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= distanceBetweenPipes)
        {
            timer = 0f;
            Instantiate(pipePrefab, new Vector3(transform.position.x, returnOffset(), transform.position.z), transform.rotation);

        }
    }
    private float returnOffset()
    {
        pipeOffset = Random.Range(transform.position.y - difficulty, transform.position.y + difficulty);
        return pipeOffset;

    }
}
