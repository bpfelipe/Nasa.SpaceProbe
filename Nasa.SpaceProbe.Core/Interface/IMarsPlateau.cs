namespace Nasa.SpaceProbe.Core.Interface
{
    using Nasa.SpaceProbe.Core.Auxiliar;

    public interface IMarsPlateau
    {
        Size Size { get; set; }

        void SetSize(int height, int width);
    }
}
