using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassVelocity : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float externalInfluence = 0.5f;
    public float easeInTime = 0.15f;
    public float easeOutTime = 0.15f;
    public float VelocityThreshold = 5.0f;

    private int ExternalInfluence = Shader.PropertyToID("_ExternalInfluence");

    public void InfluenceOnGrass(Material mat, float Xvel)
    {
        mat.SetFloat(ExternalInfluence, Xvel); 
    }
}
