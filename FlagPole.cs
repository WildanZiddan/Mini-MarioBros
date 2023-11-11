using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;

    public AudioSource poleSoundEffect;
    public AudioSource finishSoundEffect;

    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(other.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
 
        poleSoundEffect.Play();
        yield return MoveTo(player, poleBottom.position);
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, castle.position);
        finishSoundEffect.Play();

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(6f);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while (Vector3.Distance(subject.position, destination) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = destination;
    }
}
