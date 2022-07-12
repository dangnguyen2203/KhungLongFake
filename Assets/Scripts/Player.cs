using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //jumpForce l?c nh?y
    public float jumpForce;

    Rigidbody2D m_rb;

    bool m_isGround;

    GameController m_gc;

    // Start is called before the first frame update
    void Start()
    {
        //tham chi?u ??n rigidbody2d
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        //input x? l� t?t c? d? li?u ??u v�o
        if (isJumpKeyPressed && m_isGround)
        {
            //addforce th�m 1 l?c
            //vector2.up = (0,1)
            //vector.up * jumpForce = (0,1) * 5 = (0, 5) l?c lu�n h??ng l�n tr�n tr?c y
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;
        } 
            
    }
    //b?t nh?ng va ch?m gi?a c�c ??i t??ng k th? ?i xuy�n qua nhau d�ng OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            m_gc.SetGameOverState(true);
            Debug.Log("Player da va cham");
        }
    }
}
