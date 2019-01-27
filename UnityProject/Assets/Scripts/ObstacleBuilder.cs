using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour {

    [SerializeField]
    private GameObject _obstacle_left;
    [SerializeField]
    private GameObject _obstacle_right;

    public GameObject obCreate(RhythmSegment rhythm) { // Creates obstacles on track
        GameObject segment = new GameObject();

        for (int i = 0; i < rhythm.BeatObstacles.Length; i++) {
            if (rhythm.BeatObstacles[i] == RhythmSegment.ObstacleType.None) {
                continue;
            }
            GameObject obstacle;
            switch (rhythm.BeatObstacles[i]) {
                case RhythmSegment.ObstacleType.Left_Side:
                    obstacle = GameObject.Instantiate(_obstacle_left);
                    obstacle.transform.SetParent(segment.transform, false);
                    obstacle.transform.localPosition = new Vector3(-1, 0, GameConstants.beatScale * i); ;
                    break;
                case RhythmSegment.ObstacleType.Right_Side:
                    obstacle = GameObject.Instantiate(_obstacle_right);
                    obstacle.transform.SetParent(segment.transform, false);

                    obstacle.transform.localPosition = new Vector3(1, 0, GameConstants.beatScale * i); ;
                    break;
                case RhythmSegment.ObstacleType.Both_Sides:
                    obstacle = GameObject.Instantiate(_obstacle_left);
                    obstacle.transform.SetParent(segment.transform, false);

                    GameObject altObstacle = GameObject.Instantiate(_obstacle_right);
                    altObstacle.transform.SetParent(segment.transform, false);

                    obstacle.transform.localPosition = new Vector3(-1, 0, GameConstants.beatScale * i); ;
                    altObstacle.transform.localPosition = new Vector3(1, 0, GameConstants.beatScale * i); ;
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
