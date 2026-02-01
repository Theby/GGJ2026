using GGJ2026.Data;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class ClientManager : MonoBehaviour
    {
        const string ShopClientsDataRoute = "Data/ShopClients";

        public ShopClient[] ShopClients { get; private set; }

        void Awake()
        {
            LoadAllShopClients();
        }

        void LoadAllShopClients()
        {
            ShopClients = Resources.LoadAll<ShopClient>(ShopClientsDataRoute);
        }
    }
}