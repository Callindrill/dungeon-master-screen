namespace DungeonMasterScreen.Interfaces
{
    public interface IAbility
    {
        int Modifier { get; }
        int Score { get; set; }
    }
}