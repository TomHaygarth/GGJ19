using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private RhythmSegment[] m_baseSegments;

	[SerializeField]
	private float m_levelBPM = 60;
	private float m_levelLength = 60.0f;
	private float m_currentLevelTime = 0.0f;

	// level controler will populate obstacles and parent them to an ever moving root object
	// total distance to move will be dependent on the current bpm and the level length
	[SerializeField]
	private Transform m_movingRoot;
	private float m_distanceToMoveRoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
