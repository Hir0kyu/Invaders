using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public Animator animator;
    public static bool Overdrive = false;
    public static bool IsMoving = true;
    
   

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
         if(IsMoving == true)
        {
             Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
             moveVelocity = moveInput.normalized * speed;
             float x = moveInput.x;
             animator.SetFloat("Speed", Mathf.Abs(x));
       
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        }
        

        
         if (Input.GetKeyDown(KeyCode.Space))
         {
             StartCoroutine(OverDrive());
         }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

   IEnumerator OverDrive()
    {

        speed *= 2;
        Overdrive = true;
        yield return new WaitForSeconds(1);
        speed /= 2;
        Overdrive = false;
    }

    
}
