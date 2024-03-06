[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] pos;
    
    public PlayerData() {}

    public PlayerData(int health, float posX, float posY, float posZ)
    {
        this.health = health;
        this.pos = new[] { posX, posY, posZ };
    }
    
}
