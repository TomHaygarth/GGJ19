using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingBounce : MonoBehaviour
{
    [SerializeField]
    Animator buildAnim;
    public void bounce() {
        if (buildAnim != null)
        {
            buildAnim.SetTrigger("bounce");
        }
    }

    // Should be in its own script/or rename this 1 but its 2:45am
    private Material buildingMat;
    void Start()
    {
        var meshRenderer = GetComponentInChildren<Renderer>();
        if(meshRenderer != null)
        {
            buildingMat = meshRenderer.sharedMaterial;
        }

        if (buildingMat != null)
        {
            // reset the material on start
            OnScoreChanged(0.0f);
            LevelController.onScoreChanged += OnScoreChanged;
        }
    }

    void OnDestroy()
    {
        LevelController.onScoreChanged -= OnScoreChanged;
    }

    void OnScoreChanged(float newScore)
    {
        float clampedScore = Mathf.Clamp01(newScore);
        buildingMat.SetFloat("_ColAmount", clampedScore);
    }
}
