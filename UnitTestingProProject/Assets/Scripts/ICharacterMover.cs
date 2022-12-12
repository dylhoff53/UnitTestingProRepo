public interface ICharacterMover
{
    int Health { get; set; }

    int Color { get; set; }
    bool IsPlayer { get; }

    float Size { get; set; }
}