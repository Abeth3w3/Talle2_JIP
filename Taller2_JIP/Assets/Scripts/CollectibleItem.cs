using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public ItemType itemType; // Asignar desde el Inspector
    public int value = 1;     // Valor base, puedes ajustarlo según el tipo
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Actualizar GameManager si lo estás usando
            if (GameManager.Instance != null)
            {
                switch (itemType)
                {
                    case ItemType.Coin:
                        GameManager.Instance.AddCoin(value);
                        break;
                    case ItemType.Gem:
                        GameManager.Instance.AddItem(itemType, value); // o AddGem si tienes ese método
                        break;
                    case ItemType.Key:
                        GameManager.Instance.GetKey(); // o AddItem si prefieres
                        break;
                }
            }

            // Efecto visual al recoger
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect.gameObject, transform.position, Quaternion.identity);
            }

            // Destruir el objeto recogido
            Destroy(gameObject);
        }
    }
}
