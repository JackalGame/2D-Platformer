using UnityEngine;


public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 10;
    bool isPickable = true;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPickable) 
        {
            isPickable = false;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }


}
