using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator; //set reference for animator script in Unity

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //GetAxisRaw grabs both arrow keys and WASD
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical); //add both directions to get Vector3 class vector

        AnimateMovement(direction);

        transform.position += direction.normalized * speed * Time.deltaTime; //normalize Vector3 obj to get rid of excess diagonal movement, twierdzenie Pitagorasa
    }
    void AnimateMovement(Vector3 direction)
    {
        if(animator != null) //check if thers an associated animator
        {
            if(direction.magnitude < 0) //check if ther movement at all. magnitude always positive, refers to length of vector
            {
                animator.SetBool("isMoving", true); //pass bool isMoving onto animator script
                animator.SetFloat("horizontal", direction.x); //pass x value onto animator script
                animator.SetFloat("vertical", direction.y); //pass y value onto animator script
            }
            else
            {
                animator.SetBool("isMoving", false); //pass bool isMoving onto animator script
            }
        }
    }
}
