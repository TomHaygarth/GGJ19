using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName="create/rhythm segment")]
public class RhythmSegment : ScriptableObject {

	public enum ObstacleType
	{
		None,
		Left_Side,
		Right_Side,
		Both_Sides
	};

	[SerializeField]
	private AudioClip m_track;

	[SerializeField]
	private int m_BPM = 125;

	[SerializeField]
	private ObstacleType[] m_beatObstacles;

	public int BPM { get { return m_BPM; } }
	public AudioClip Track { get { return m_track; } }
	public ObstacleType[] BeatObstacles { get { return m_beatObstacles; } }


}
