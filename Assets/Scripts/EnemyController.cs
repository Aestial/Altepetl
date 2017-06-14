using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    private float velocity;
    private float distance;
    private GameObject player;
    private GameObject enemyGod;
    private float life = 10;

    public float attackDistance;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyGod = GameObject.FindGameObjectWithTag("EnemyGod");
	}
	
	// Update is called once per frame
	void Update () {
        distance = GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target.position.x - transform.position.x;
        velocity = distance /Time.deltaTime;
        if (Mathf.Abs(distance) <= attackDistance) {
            Attack();
        }
        if (velocity > 0 && !m_FacingRight) {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (velocity < 0 && m_FacingRight) {
            // ... flip the player.
            Flip();
        }
        
    }

    void ApplyDamage(float damage) {
        life = life - damage;
        if (life <= 0)
            enemyGod.SendMessage("AddScore", 1);
            Destroy(gameObject);
    }

    private void Attack() {
        player.GetComponent<PlayerController>().lives--;
    }

    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
