using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorMove : MonoBehaviour
{

    public float runSpeed = 5;
    public float rotationSpeed = 250;
    private Animator animator;

    public float x, y;

    public Rigidbody rb;
    public float fuerzadesalto = 8f;
    public bool puedosaltar =false;
    bool isjump = false;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puedosaltar = false;
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        Vector3 Floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, Floor, 1.03f))
        {
            puedosaltar = true;
            print("Contacto con el suelo");
        }
        else
            {
            puedosaltar = false;
            print("No hay contacto con el suelo");
        }

        isjump = Input.GetButtonDown("Jump");

        if (isjump && puedosaltar)
        {
            animator.Play("Jump");
            rb.AddForce(new Vector3(0, fuerzadesalto, 0), ForceMode.Impulse);
        }
    }

}
   


