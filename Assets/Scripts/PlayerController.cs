using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput = 0f;
    float verticalInput = 0f;
    Rigidbody rb;
    [SerializeField]Transform orientation;
    [SerializeField] LayerMask layerMask;

    Vector3 safePosition;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckPosition();
    }

    void FixedUpdate()
    {
        MoveCar();
    }

    void GetInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Debug.Log($"{horizontalInput} \n{verticalInput}");
    }

    void MoveCar()
    {
        rb.AddForce(orientation.forward * verticalInput * 500f * Time.deltaTime);
        //rb.AddTorque(Vector3.up * horizontalInput * 25f * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * 100f * Time.deltaTime);

        //Debug.Log(rb.velocity.magnitude);
        if(rb.velocity.magnitude > 13f)
            rb.velocity = rb.velocity.normalized * 13f;

        if(transform.position.y < -10f)
        {
            rb.velocity = Vector3.zero;
            transform.position = safePosition;
        }
        

        //if (rb.angularVelocity.y > 1f)
            //rb.velocity = new Vector3(rb.angularVelocity.x, 1f, rb.angularVelocity.z);
    }

    void CheckPosition()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 10f, layerMask))
        {
            if(hit.collider != null && hit.collider.tag == "Ground")
            {
                safePosition = hit.collider.transform.position;
                //Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
