using UnityEngine;
using UnityEngine.InputSystem;

public class UDJAAGANDU : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D myRigidbody;
    public logicscript logic;
    public bool birdIsAlive = true;

    [Header("--------Audio--------")]
    public AudioSource sfxSource;
    public AudioClip wing;
    public AudioClip die;
    public AudioClip hit;
    public AudioClip point;
    public AudioClip swoosh;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool pressed =
            (Keyboard.current != null && Keyboard.current.spaceKey.isPressed && birdIsAlive == true) ||           // editor
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed && birdIsAlive == true); // android

        if (pressed)
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, speed);

            // 🔊 Play wing sound when flapping
            if (!sfxSource.isPlaying) 
                sfxSource.PlayOneShot(wing);
        }
        else
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 🔊 Play die + hit sound when bird crashes
        sfxSource.PlayOneShot(hit);
        sfxSource.PlayOneShot(die);

        logic.gameOver();
        birdIsAlive = false;
    }

    // You can call this from Logic when scoring
    public void PlayPointSound()
    {
        sfxSource.PlayOneShot(point);
    }

    // Optional swoosh trigger if you want to use it
    public void PlaySwooshSound()
    {
        sfxSource.PlayOneShot(swoosh);
    }
}
