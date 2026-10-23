using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private CharacterController character;
    private Vector2 direction;
    private Animator animator;
    private bool Estado = true;
    private bool isDie = false;
    

    public float gravity = 9.81f*2f;
    public float jumpForce = 8f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        character = GetComponent<CharacterController>();

    }
    private void Update()
    {
        direction.y -= gravity * Time.deltaTime;
        
        if (character.isGrounded && direction.y < 0)
        {

            animator.SetBool("isJump", false);
            direction.y = -2f;
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isJump", true);
        }

        if (Input.GetButtonDown("Jump") && character.isGrounded)
        {
            direction.y = jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Estado && !isDie) {
            Time.timeScale = 0f;
            Estado =!Estado;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !Estado)
        {
            Time.timeScale = 1f;
            Estado = !Estado;
        }
        character.Move(direction * Time.deltaTime);

    }
    void died()
    {
        GameManage.Instance.GameOver();

    }
    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            died();
        }

    }

}
