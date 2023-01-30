using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed = 0;
    public float jumpForce = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private bool canJump = true;

    private float movementX;
    private float movementY;
    private float movementZ;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    IEnumerator PlayerJumpingDelay()
    {
        yield return new WaitForSeconds(1f);
        canJump = true;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if(count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        Vector3 jump = new Vector3(0.0f, 1 + movementZ, 0.0f);

        rigidbody.AddForce(movement * speed);

        if (Input.GetKey("space") && canJump == true)
        {
            Debug.Log("Hello");
            rigidbody.AddForce(jump * jumpForce);
            canJump = false;
            StartCoroutine(PlayerJumpingDelay());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }
}
