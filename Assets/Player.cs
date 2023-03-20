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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FlagButtom.gameObject.SetActive(false);
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
        if (other.gameObject.CompareTag("Flag"))
        {
            Destroy(other.gameObject); // destroy the object with the specified tag
            getFlag = true;
            FlagButtom.gameObject.SetActive(true);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        return transform.position;
    }
    public void OnClick()
    {
        FlagButtom.gameObject.SetActive(false);
        getFlag = false;
        Vector2 playerPosition = GetPlayerPosition();
            
        Instantiate(ownFlag,playerPosition, Quaternion.identity);

        Instantiate(obj, new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
    }
}
