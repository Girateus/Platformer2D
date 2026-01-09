using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Avalon Datas/Items")]
public class SO_Items : ScriptableObject
{

    [SerializeField] private int _goldCoin;
    [SerializeField] private int _chestCoin;
    
    public int GoldCoin => _goldCoin;
    //public int ChestCoin => _chestCoin;

}
