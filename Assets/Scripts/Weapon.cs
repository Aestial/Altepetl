using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private GameObject player;
    private PlayerController control;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (control.attacking && coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", 10);
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (control.attacking && coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", 10);
    }
}
