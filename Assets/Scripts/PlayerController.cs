using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int maxLives = 3;
    public Transform face;
    [HideInInspector] public int lives;
    [HideInInspector] public bool attacking;
    private Animator animator;
    
    // Use this for initialization
    void Start () {
        lives = maxLives;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if ( Input.GetKeyUp(KeyCode.RightControl) ) {
            animator.SetTrigger("Hit");
        }
        attacking = !animator.GetCurrentAnimatorStateInfo(1).IsName("Waiting");
        AttackingFace(attacking);
	}
    
    void AttackingFace(bool attacking) {
        face.GetComponent<SpriteRenderer>().color = (attacking) ? Color.red:Color.white;
    }   
}
