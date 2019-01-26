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

	[SerializeField]
	private Transform m_movingRoot;
	private readonly Vector3 m_movingRootDirection = new Vector3(0.0f, 0.0f, -1.0f);

	private List<RhythmSegment> m_currentSegments;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
