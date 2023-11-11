using UnityEngine;

public class DeathBarrier : MonoBehaviour
{

    public AudioSource dieSoundEffect;

   private void OnTriggerEnter2D(Collider2D other)
   {
    if (other.CompareTag("Player"))
    {
        other.gameObject.SetActive(false);
        GameManager.Instance.ResetLevel(4f);
        dieSoundEffect.Play();
    }
    else
    {
        Destroy(other.gameObject);
    }
   }
}
