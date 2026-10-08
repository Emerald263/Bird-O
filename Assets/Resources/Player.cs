using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
    void FixedUpdate()
    { 
        rb.linearVelocity = movementDirection * movementSpeed;
    }
    
    
        
    
}

