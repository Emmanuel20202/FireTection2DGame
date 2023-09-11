using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        gameObject.SetActive(false);
    }
}
