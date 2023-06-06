using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;

public class Mouvement : MonoBehaviour
{
    [Range(1f,10f)]
    public float Speed;
    [Range(1.1f, 2f)]
    public float SprintMultiplier;
    public float JumpHeight;
    public float MaxStamina = 100;
    public bool IsSprinting;

    private Rigidbody pv_RB;
    private int pv_JumpCount;
    [SerializeField]
    private float pv_CurrentStamina;


    private void Awake()
    {
        pv_RB = GetComponent<Rigidbody>();
        pv_CurrentStamina = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Sprint();
    }

    void Move()
    {
        float actSpeed = Speed;
        IsSprinting = false;

        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.Z))
        {
            velocity += transform.forward;
            if (Input.GetKey(KeyCode.LeftShift) && pv_CurrentStamina > 5)
            {
                IsSprinting = true;
                actSpeed *= SprintMultiplier;
            }
        }

        if (Input.GetKey(KeyCode.S))
            velocity -= transform.forward;
        if (Input.GetKey(KeyCode.Q))
            velocity -= transform.right;
        if (Input.GetKey(KeyCode.D))
            velocity += transform.right;

        velocity *= actSpeed * Time.deltaTime * 1000f;
        float gravity = pv_RB.velocity.y;
        pv_RB.velocity = new Vector3(velocity.x,gravity,velocity.z);

    }

    void Sprint()
    {
        if (IsSprinting)
        {
            pv_CurrentStamina -= 25 * Time.deltaTime;
            if (pv_CurrentStamina < 10)
                pv_CurrentStamina = 0;

        }
        else 
        {
            pv_CurrentStamina += 15 * Time.deltaTime;
        }

        pv_CurrentStamina = Mathf.Clamp(pv_CurrentStamina, 0, MaxStamina);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pv_JumpCount > 0)
        {
            pv_RB.AddForce(Vector3.up * JumpHeight,ForceMode.Impulse);
            pv_JumpCount--;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.First().point.y < transform.position.y)
            pv_JumpCount = 1;
    }


}
