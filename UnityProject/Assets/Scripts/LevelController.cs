using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private RhythmSegment[] m_baseSegments;

	[SerializeField]
	private ObstacleBuilder m_rhythmGenerator;

	[SerializeField]
	private float m_levelLength = 60.0f;
	private float m_currentLevelTime = 0.0f;

	[SerializeField]
	private Transform m_movingRoot;
	private readonly Vector3 m_movingRootDirection = new Vector3(0.0f, 0.0f, -1.0f);

	private List<RhythmSegment> m_currentSegments = new List<RhythmSegment>();
	int m_currentSegmentBeat = 0;

	[SerializeField]
	bool m_generateFullTrack = false;

	// Use this for initialization
	void Start () {
		if (m_generateFullTrack == false)
		{
		// generate first 3 segments
			for (int i = 0; i < 3 ; ++i) {
				if (i >= m_baseSegments.Length)
				{
					break;
				}
				ConstructTrackSegment(m_baseSegments[i]);
			}
		}
		else
		{
			for (int i = 0; i < m_baseSegments.Length; ++i) {
				ConstructTrackSegment(m_baseSegments[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void ConstructTrackSegment(RhythmSegment segment)
	{
		int segment_distance_offset = 0;
		for (int i = 0; i < m_currentSegments.Count; ++i)
		{
			segment_distance_offset += m_currentSegments[i].BeatObstacles.Length;
		}

		GameObject new_segment = m_rhythmGenerator.obCreate(segment);
		new_segment.transform.SetParent(m_movingRoot, false);
		new_segment.transform.position = Vector3.forward * (float)segment_distance_offset;
		m_currentSegments.Add(segment);
	}
}
