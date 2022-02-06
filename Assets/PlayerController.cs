using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 5;
    public float jumpTime = .5f;

    public AudioClip[] audioClips;
    public AudioSource music;

    private Vector3 startPos;
    private bool jumping = false;
    private Animator animator;
    private AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            StartCoroutine(DeathMusic(1));
            Time.timeScale = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !jumping)
        {
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
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

    IEnumerator DeathMusic(float time)
    {
        for (float t = 0; t < 1; t += Time.unscaledDeltaTime / time)
        {
            music.pitch = Mathf.Lerp(1, 0, t);
            yield return null;
        }
    }
}
