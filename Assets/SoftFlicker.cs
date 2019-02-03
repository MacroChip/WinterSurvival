using UnityEngine;

[RequireComponent(typeof(Light))]
public class SoftFlicker : MonoBehaviour
{
    public float minIntensity;
    public float maxIntensity;

    private float random;

    void Start()
    {
        random = Random.Range(0.0f, 65535.0f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
