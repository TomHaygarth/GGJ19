using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour {

    [SerializeField]
    private GameObject[] _obstacles;

    GameObject obCreate(RhythmSegment rhythm) { // Creates obstacles on track
        GameObject segment = new GameObject();

        for (int i = 0; i < rhythm.BeatObstacles.Length; i++) {
            if (rhythm.BeatObstacles[i] == RhythmSegment.ObstacleType.None) {
                continue;
            }
            int idx = Random.Range(0, _obstacles.Length);
            GameObject obstacle = GameObject.Instantiate(_obstacles[idx]);
            obstacle.transform.SetParent(segment.transform, false);
            switch (rhythm.BeatObstacles[i]) {
                case RhythmSegment.ObstacleType.Left_Side:
                    obstacle.transform.localPosition = new Vector3(-1, 0, 1 * i); ;
                    break;
                case RhythmSegment.ObstacleType.Right_Side:
                    obstacle.transform.localPosition = new Vector3(1, 0, 1 * i); ;
                    break;
                case RhythmSegment.ObstacleType.Both_Sides:
                    idx = Random.Range(0, _obstacles.Length);
                    GameObject altObstacle = GameObject.Instantiate(_obstacles[idx]);
                    altObstacle.transform.SetParent(segment.transform, false);
                    obstacle.transform.localPosition = new Vector3(-1, 0, 1 * i); ;
                    altObstacle.transform.localPosition = new Vector3(1, 0, 1 * i); ;
                    break;
            }
        }
        return segment;
    }

    public RhythmSegment testOb;

	// Use this for initialization
	void Start () {
        if (testOb != null) { obCreate(testOb); }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
