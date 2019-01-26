using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBuilder : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _buildings;
    public GameObject[] _path;

    public GameObject streetLine(RhythmSegment rhythm)
    { // Creates buildings next to track
        GameObject streetSection = new GameObject();

        for (int i = 0; i < rhythm.BeatObstacles.Length; i += 4)
        {
            if (rhythm.BeatObstacles[i] == RhythmSegment.ObstacleType.None)
            {
                continue;
            }
            int idx = Random.Range(0, _buildings.Length);
            GameObject rBuild = GameObject.Instantiate(_buildings[idx]);
            rBuild.transform.SetParent(streetSection.transform, false);
            rBuild.transform.localPosition = new Vector3(4, 0, 1 * i); ;
            rBuild.transform.Rotate(Vector3.up,-90);

            idx = Random.Range(0, _buildings.Length);
            GameObject lBuild = GameObject.Instantiate(_buildings[idx]);
            lBuild.transform.SetParent(streetSection.transform, false);
            lBuild.transform.localPosition = new Vector3(-4, 0, 1 * i); ;
            lBuild.transform.Rotate(Vector3.up, 90);
        }
        GameObject road = GameObject.Instantiate(_path[0]);
        road.transform.SetParent(streetSection.transform, false);
        road.transform.localPosition = new Vector3(0, 0, 1);
        road.transform.localScale = new Vector3(1.6f, 0.4f, 1.5f);
        return streetSection;
    }

    public RhythmSegment testBuild;

    // Use this for initialization
    void Start()
    {
        if (testBuild != null) { streetLine(testBuild); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
