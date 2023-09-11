using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private void Start()
    {
        // Destroy the OnboardingManager object if it exists in the scene (e.g., when coming from the onboarding scene)
        var onboardingManager = GameObject.FindObjectOfType<OnBoardingManager>();
        if (onboardingManager != null)
        {
            Destroy(onboardingManager.gameObject);
        }
    }
}
