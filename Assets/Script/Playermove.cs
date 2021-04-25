using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    [SerializeField] private AudioSource Jumping;
    [SerializeField] private AudioSource Death;
    [SerializeField] private AudioSource Steap;

    public float runSpeed = 20f;
    float horizontalMove = 0f;

    float SX, SY;

    bool jump = false;
    bool crouch = false;
    void Start()
    {
        SX = transform.position.x;
        SY = transform.position.y;

    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Run", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJamping", true);
            Jumping.Play();
            Steap.Stop();
        }
        if (Input.GetKeyDown(KeyCode.A)||(Input.GetKeyDown(KeyCode.D)))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.D)))
            Steap.Stop();
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.A)))
            Steap.Stop();

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platforma"))
        {
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.name == "DeadSpace" || collision.gameObject.name == "error" || collision.gameObject.name == "Spam" || collision.gameObject.name == "DS" || collision.gameObject.name == "Zona")
        {
            Death.Play();
            transform.position = new Vector3(SX, SY, transform.position.z);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platforma"))
            this.transform.parent = null;
    }
    public void OnLanding()
    {
        animator.SetBool("IsJamping", false);
    }

    public void OnCrouch(bool isCrouch)
    {
        animator.SetBool("IsCrouch", isCrouch);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
            Collect.TheGem += 1;
            Destroy(collision.gameObject);
    }
}
