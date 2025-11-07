using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public bool isDead = false;
    public bool isGoal = false;
    private Rigidbody2D rb;

    public GameObject gameOver;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!isGoal && !isDead)
        {
            float x = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
        }
        if (isGrounded && !isGoal && !isDead && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // 上方向に速度を与える
        }

        if(isDead)
        {
            gameOver.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("TitleScene");
        }

        if (isGoal)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            isGoal = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
        }
    }
}
