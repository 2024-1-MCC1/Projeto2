
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int numberOfItems = 0; //Valor inicial do contador

    public int NumberOfContador // Propriedade para acessar o contador de itens
    {
        get { return numberOfItems; }
    }

    // M�todo para incrementar o contador de itens
    public void IncrementContador()
    {
        numberOfItems++;
    }
}