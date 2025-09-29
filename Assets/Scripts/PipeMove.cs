using UnityEngine;
using UnityEngine.UIElements;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private int pipeMoveSpeed;

    private void Update()
    {
        transform.position += Vector3.forward * -pipeMoveSpeed * Time.deltaTime;
    }
}
