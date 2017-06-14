using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FloorCreator : MonoBehaviour {

    public GameObject stairsPrefab;
    public GameObject floorPrefab;

    public int numPieces;
    public float stairsWidth = 3.8f;
    public float floorWidth = 5.0f;

    private int lastNumPieces;

	void Update () {
	    if ( lastNumPieces != numPieces) {
            Restart();
        }
	}

    private void Restart() {
        var childCount = transform.childCount;
        if ( childCount > 0 ) {
            
            for (int i = 0; i < childCount; i++) {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
        SetPieces();
    }

    void SetPieces() {
        GameObject stairs = Instantiate(stairsPrefab, transform.position, Quaternion.identity) as GameObject;
        stairs.transform.parent = gameObject.transform;
        for (int i = 0; i < numPieces; i++) {
            var newFloor = Instantiate(floorPrefab, transform.position + new Vector3((i) * floorWidth + stairsWidth, 0.0f), Quaternion.identity) as GameObject;
            newFloor.transform.parent = gameObject.transform;
        }
        lastNumPieces = numPieces;
    }
}
