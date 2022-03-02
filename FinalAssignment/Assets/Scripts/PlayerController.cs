using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float playerSpeed;
    public float playerJump;
    bool isJumping = false;
    public GameObject loseScreen;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * playerSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * playerJump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping=false;

        if (collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
