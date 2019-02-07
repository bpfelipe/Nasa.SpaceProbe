namespace Nasa.SpaceProbe.Core.Interface
{
    using Nasa.SpaceProbe.Core.Auxiliar;

    public interface ISpaceProbe
    {
        Position Position { get; set; }

        void Land(IMarsPlateau plateau, Position position, CardinalDirections direction);
    }
}
