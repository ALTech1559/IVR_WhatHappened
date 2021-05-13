using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LastMiniGameController : MonoBehaviour
{
    private float speed = 0;
    [Range(50, float.MaxValue)]
    [SerializeField] private float jump_force;
    [SerializeField] private AudioSource failSound;
    [SerializeField] private ParticleSystem jumpPatricalAnimation;
    private Rigidbody rigidbody;
    private Animator animator;
    private bool on_ground;
    internal static event UnityAction setOffScene;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    public void Jump()
    {
        if (on_ground)
        {
            //add force to the player
            rigidbody.AddForce(Vector3.up * jump_force);
            animator.SetTrigger("Jump");
            on_ground = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check the collisions
        if (collision.gameObject.tag == "Ground")
        {
            jumpPatricalAnimation.Play();
        }

        if (collision.gameObject.GetComponent<CapsuleCollider>() != null)
        {
            StartCoroutine(LoadScene("Win"));
        }

        if (collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            on_ground = true;
        }

        if (collision.gameObject.GetComponent<ObstacleController>() != null)
        {
            failSound.Play();
            animator.Play("FallDown");
            if (!SceneLoading.statement)
            {
                Invoke("ReloadScene", 1);
            }

        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadScene(string scene_name)
    {
        setOffScene?.Invoke();
        yield return new WaitForSeconds(1.15f);
        SceneLoading.ChangeScene(scene_name);
    }
}
