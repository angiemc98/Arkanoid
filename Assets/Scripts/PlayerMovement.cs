using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public Rigidbody2D rb;
   public float speed = 25f;
   public float limit= 8f;
   private float inputValue;
  

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxis("Horizontal");
        float PosX = transform.position.x + inputValue*speed* Time.deltaTime;

        PosX = Mathf.Clamp(PosX, -limit, limit);

        transform.position = new Vector2(PosX, transform.position.y);
    }
}
