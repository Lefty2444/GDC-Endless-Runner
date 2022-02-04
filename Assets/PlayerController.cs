using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 5;
    public float jumpPowerup;
    public float minJump = 3;
    public float maxJump = 6;
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
    //while playing the game, i ran into an issue where spikes would spawn too close, and jumping over one would cause you to land right on the next
    //i see two ways to fix this issue: 
    //make the player jump higher or shorter depending on how long they hold the space bar
    //make the spikes more spaced apart
    //i think the space bar one is the best
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !jumping)
        {

            jumpHeight = jumpHeight + (jumpPowerup);
            if (jumpHeight > maxJump)
            {
                jumpHeight = maxJump;
            }
            //StartCoroutine(Jump());
        }
        if (Input.GetButtonUp("Jump") && !jumping)
        {
            StartCoroutine(Jump());
            Debug.Log(jumpHeight);
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
        jumpHeight = minJump;
    }
}
