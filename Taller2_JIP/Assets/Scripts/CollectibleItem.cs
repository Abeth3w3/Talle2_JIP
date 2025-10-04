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
            switch (itemType)
            {
                case ItemType.Coin:
                case ItemType.Gem:
                    GameManager.Instance.AddItem(itemType, value);
                    break;

                case ItemType.Key:
                    GameManager.Instance.GetKey(); 
                    break;
            }

            if (pickupSfx != null)
                AudioSource.PlayClipAtPoint(pickupSfx, transform.position);

            Destroy(gameObject); 
        }
    }
}
