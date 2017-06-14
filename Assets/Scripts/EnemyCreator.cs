using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 10.0f;
    public Text scoreText;

    private float lastTime = 0.0f;
    private Transform player;
    private int score = 0;
    private GameObject newEnemy;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        newEnemy = Instantiate(enemyPrefab, transform.GetChild(1).position, Quaternion.identity) as GameObject;
        newEnemy.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = player;
        UpdateScoreText();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - lastTime > spawnTime ) {
            lastTime = Time.time;
            int childIndex = Mathf.FloorToInt(105.0f*Time.time) % 2;
            newEnemy = Instantiate(enemyPrefab, transform.GetChild(childIndex).position, Quaternion.identity) as GameObject;
            newEnemy.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = player;
        }
	}

    void AddScore(int addScore) {
        score += addScore;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = score.ToString();
    }
}
