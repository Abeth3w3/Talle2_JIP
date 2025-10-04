using UnityEngine;

public enum ItemType { Coin, Gem, Key }

public class CollectibleItem : MonoBehaviour
{
    public ItemType itemType = ItemType.Coin;
    public int value = 1;
    public AudioClip pickupSfx;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddItem(itemType, value);

            if (pickupSfx != null)
                AudioSource.PlayClipAtPoint(pickupSfx, transform.position);

            Destroy(gameObject);
        }
    }
}
