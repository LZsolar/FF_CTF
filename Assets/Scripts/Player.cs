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
    private bool getFlag = false;
    private bool rotate = false;

    public Button MoveButton;
    public Button FlagButtom;

    private bool isMoving = false;

    public int PlayerNumber;
    public GameManager gm;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FlagButtom.gameObject.GetComponent<Button>().interactable = false;
    }
    public void Moving()
    {
        isMoving = true;
    }
    public void stopMoving()
    {
        isMoving = false;
        rotate = !rotate;
    }
    void FixedUpdate()
    {
        
        if (isMoving)
        {
            rb.velocity = transform.up * moveSpeed;

        }
        // Stop moving the player when the key is released
        else if(rotate)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flag")  && !this.getFlag)
        {
            Destroy(other.gameObject); // destroy the object with the specified tag
            getFlag = true;
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
        FlagButtom.gameObject.GetComponent<Button>().interactable = false;
        getFlag = false;
        Vector2 playerPosition = GetPlayerPosition();
            
        Instantiate(ownFlag,playerPosition, Quaternion.identity);

        gm.flagPosition.Add(playerPosition);
        gm.flagcolor.Add(PlayerNumber);
    }
}
