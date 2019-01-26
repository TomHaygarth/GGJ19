using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Rhythm Segment")]
public class RhythmSegment : ScriptableObject {

	public enum ObstacleType
	{
		None,
		Left_Side,
		Right_Side,
		Both_Sides
	};

	[SerializeField]
	private AudioClip[] m_tracks;

	[SerializeField]
	private int m_BPM = 125;

	[SerializeField]
	private ObstacleType[] m_beatObstacles;

	public int BPM { get { return m_BPM; } }
	public AudioClip[] Tracks { get { return m_tracks; } }
	public ObstacleType[] BeatObstacles { get { return m_beatObstacles; } }
}
