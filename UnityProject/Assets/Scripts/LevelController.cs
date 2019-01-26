﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private RhythmSegment[] m_baseSegments;
	private int m_nextSegmentIdx = 0;

	[SerializeField]
	private ObstacleBuilder m_rhythmGenerator;
	[SerializeField]
	private StreetBuilder m_streetGenerator;

	[SerializeField]
	private float m_levelLength = 60.0f;
	private float m_currentLevelTime = 0.0f;

	[SerializeField]
	private Transform m_movingRoot;
	private readonly Vector3 m_movingRootDirection = new Vector3(0.0f, 0.0f, -1.0f);

	private List<RhythmSegment> m_currentSegments = new List<RhythmSegment>();
	int m_currentSegmentBeat = 0;

	private float m_timeSinceLastBeat = 0.0f;
	private bool m_currentBeatSuccess = false;
	private float m_beatsPerSecond = 0.0f;
	private float m_beatMinReactionTime = 0.0f;
	private float m_moveUnitsPerSecond = 0.0f;

	private const float m_beatTimeReactionPercantage = 0.5f;

	[SerializeField]
	private GameObject m_audioSourcesObject;
	private AudioSource[] m_audioSources;


	[SerializeField]
	bool m_generateFullTrack = false; // A bit of a hack flag to avoid pooling and building on the fly but will probably make the game run like ass

	// Use this for initialization
	void Start () {

		m_audioSources = m_audioSourcesObject.GetComponents<AudioSource>();

		if (m_generateFullTrack == false)
		{
		// generate first 3 segments
			for (m_nextSegmentIdx = 0; m_nextSegmentIdx < 3 ; ++m_nextSegmentIdx) {
				if (m_nextSegmentIdx >= m_baseSegments.Length)
				{
					break;
				}
				ConstructTrackSegment(m_baseSegments[m_nextSegmentIdx]);
			}
		}
		else
		{
			for (m_nextSegmentIdx = 0; m_nextSegmentIdx < m_baseSegments.Length; ++m_nextSegmentIdx) {
				ConstructTrackSegment(m_baseSegments[m_nextSegmentIdx]);
				++m_nextSegmentIdx;
			}
		}
		SetNextSegmentInfo();
	}
	
	// Update is called once per frame
	void Update () {
		m_movingRoot.localPosition += (m_movingRootDirection * (m_moveUnitsPerSecond * Time.deltaTime));
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

		GameObject new_street_segment = m_streetGenerator.streetLine(segment);
		new_street_segment.transform.SetParent(m_movingRoot, false);
		new_street_segment.transform.position = Vector3.forward * (float)segment_distance_offset;

		m_currentSegments.Add(segment);
	}

	void FixedUpdate()
	{
		m_timeSinceLastBeat += Time.fixedDeltaTime;
		if(m_timeSinceLastBeat >= m_beatsPerSecond)
		{
			Debug.LogFormat("m_timeSinceLastBeat : {0}", m_timeSinceLastBeat);
			SetNextBeat();
			m_timeSinceLastBeat += Time.fixedDeltaTime;

			// if we've passed the last beat for this segemnt try to move to the next one
			if(m_currentSegmentBeat >= m_currentSegments[0].BeatObstacles.Length)
			{
				// if we have more than one segment then move on
				if(m_currentSegments.Count > 1)
				{
					m_currentSegments.RemoveAt(0);
					SetNextSegmentInfo();

					// if we have another segment to create then lets do that
					if (m_nextSegmentIdx < m_baseSegments.Length);
					{
						ConstructTrackSegment(m_baseSegments[m_nextSegmentIdx]);
						++m_nextSegmentIdx;
					}
				}
				else {
					// we'vre reached the end
					Debug.Log("YAY :) You Win!!!!");
				}
			}
		}
	}

	void SetNextSegmentInfo()
	{
		m_currentSegmentBeat = 0;
		m_beatsPerSecond = 60.0f / (float)(m_currentSegments[0].BPM);
		m_moveUnitsPerSecond = GameConstants.beatScale / m_beatsPerSecond;

		Debug.LogFormat("m_beatsPerSecond : {0}", m_beatsPerSecond);
		Debug.LogFormat("m_currentSegmentBeat : {0}", m_currentSegmentBeat);
		Debug.LogFormat("m_timeSinceLastBeat : {0}", m_timeSinceLastBeat);

		// loop through all track of next segment and find matching audio clips
		var segment_tracks = m_currentSegments[0].Tracks;
		for(int i = 0; i < segment_tracks.Length; ++i)
		{
			for(int j = 0; j < m_audioSources.Length; ++j)
			{
				if(segment_tracks[i] == m_audioSources[j].clip)
				{
					m_audioSources[j].Stop();
					m_audioSources[j].Play();
					break;
				}
			}
		}
	}

	void SetNextBeat()
	{
		m_timeSinceLastBeat = 0;
		m_currentBeatSuccess = false;
		++m_currentSegmentBeat;
	}
}
