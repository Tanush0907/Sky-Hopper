using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private int playerJumpForce;
    [SerializeField] private LayerMask pipeLayerMask;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private UIManager uiManager;
    private InputSystem_Actions inputActions;

    private void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        if (inputActions != null)
            inputActions.Player.Jump.performed -= Jump;

        inputActions?.Disable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        playerAnim.SetBool("IsJumping", true);
        playerAudioSource.Play();

        Vector3 vel = playerRigidbody.linearVelocity;
        vel.y = 0f;
        playerRigidbody.linearVelocity = vel;

        playerRigidbody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);

        StartCoroutine(ResetJumpBool());
    }

    private IEnumerator ResetJumpBool()
    {
        yield return new WaitForSeconds(.5f);
        playerAnim.SetBool("IsJumping", false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Time.timeScale = 0f;
            uiManager.ShowGameOver();
        }
    }

}
