using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;

    public string CurrentColor;

    public SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;


    private void Start()
    {
        SetRandomColor();
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }   

        if(col.tag != CurrentColor)
        {
            Debug.Log("Shit!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                CurrentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                CurrentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                CurrentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                CurrentColor = "Purple";
                sr.color = colorPurple;
                break;
        }
    }
}
