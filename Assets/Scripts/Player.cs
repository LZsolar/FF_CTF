using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    public GameObject obj;
    public GameObject ownFlag;
    public GameObject HeadFlag;
    private bool getFlag = false;
    private bool rotate = false;

    public Button MoveButton;
    public Button FlagButtom;

    private bool isMoving = false;

    public int PlayerNumber;
    public GameManager gm;

    public AudioClip buttonSound;
    public AudioClip placeSound;
    private AudioSource audioSource;
    private Animator animator;
    public GameObject shadow;
    private Animator shadowAnimator;

    void Start()
    {
        animator = GetComponent<Animator>();
        shadowAnimator = shadow.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        FlagButtom.gameObject.GetComponent<Button>().interactable = false;
        HeadFlag.SetActive(false);
    }
    public void Moving()
    {
        isMoving = true;
        animator.SetBool("moving", true);
        shadowAnimator.SetBool("moving", true);
    }
    public void stopMoving()
    {
        isMoving = false;
        rotate = !rotate;
        animator.SetBool("moving", false);
        shadowAnimator.SetBool("moving", false);
    }
    void FixedUpdate()
    {
        if (gm.isGameStart)
        {
            if (isMoving)
            {
                rb.velocity = transform.up * moveSpeed;

            }
            // Stop moving the player when the key is released
            else if (rotate)
            {
                isMoving = false;
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                rb.velocity = Vector2.zero;
            }
            else
            {
                isMoving = false;
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                rb.velocity = Vector2.zero;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flag")  && !this.getFlag)
        {
            audioSource.PlayOneShot(buttonSound);
            Destroy(other.gameObject); // destroy the object with the specified tag
            getFlag = true; HeadFlag.SetActive(true);
            FlagButtom.gameObject.GetComponent<Button>().interactable = true;
            Instantiate(obj, new Vector2(Random.Range(-7, 7), Random.Range(-4, 4)), Quaternion.identity);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        return transform.position;
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(placeSound);
        FlagButtom.gameObject.GetComponent<Button>().interactable = false;
        getFlag = false; HeadFlag.SetActive(false);
        Vector2 playerPosition = GetPlayerPosition();
            
        Instantiate(ownFlag,playerPosition, Quaternion.identity);

        gm.flagPosition.Add(playerPosition);
        gm.flagcolor.Add(PlayerNumber);
    }
}
