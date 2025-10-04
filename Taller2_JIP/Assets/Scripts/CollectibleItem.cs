using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public ItemType itemType; 
    public int value = 1;     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (GameManager.Instance != null)
            {
                switch (itemType)
                {
                    case ItemType.Coin:
                        GameManager.Instance.AddCoin(value);
                        break;
                    case ItemType.Gem:
                        GameManager.Instance.AddItem(itemType, value); 
                        break;
                    case ItemType.Key:
                        GameManager.Instance.GetKey(); 
                        break;
                }
            }

      
            Destroy(gameObject);
        }
    }
}
