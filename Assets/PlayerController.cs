using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 5;
    public float jumpTime = .5f;

    private Vector3 startPos;
    private bool jumping = false;
    private Animator animator;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Time.timeScale = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        jumping = true;
        animator.SetBool("jumping", true);
        for (float t = 0; t < 1; t += Time.deltaTime / jumpTime)
        {
            Vector3 newPos = startPos;
            newPos.y = startPos.y + jumpHeight * (-t)*(t - 1);
            transform.position = newPos;
            yield return null;
        }
        transform.position = startPos;
        jumping = false;
        animator.SetBool("jumping", false);
    }

    public void Retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
