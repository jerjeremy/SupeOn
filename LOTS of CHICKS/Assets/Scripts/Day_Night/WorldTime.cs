using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour
    {
        public float duration = 30; // Changed the default duration to 30

        [SerializeField] private Gradient gradient;
        private Light2D _light; // Corrected variable name to start with lowercase letter
        private float _startTime;

        private void Awake()
        {
            _light = GetComponent<Light2D>(); // Corrected variable name to start with lowercase letter
            _startTime = Time.time;
        }

        private void Update()
        {
            // Calculate the time elapsed since the start time
            var timeElapsed = Time.time - _startTime;

            // Calculate the percentage based on the sine of the time elapsed
            var percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2);

            // Clamp the percentage to be between 0 and 1
            percentage = Mathf.Clamp01(percentage);

            _light.color = gradient.Evaluate(percentage);
        }
    }
}