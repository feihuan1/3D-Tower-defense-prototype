using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindFirstObjectByType<Bank>();
        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
        }
        return false;
    }
}
