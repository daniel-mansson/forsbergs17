using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour {
    private ParticleSystem ps;
    public float enhancedStrenth = 10f;
    public float defaultStrength = 1f;

    public bool inLight;

    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        var enhancer = ps.noise;

        if (inLight) {
            enhancer.strength = enhancedStrenth;
        } else {
            enhancer.strength = defaultStrength;
        }
    }

    public void setLightState(bool state) {
        inLight = state;
    }
}
