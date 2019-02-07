namespace Nasa.SpaceProbe.Core.Entities
{
    using Nasa.SpaceProbe.Core.Auxiliar;
    using Nasa.SpaceProbe.Core.Interface;
    using System.Collections.Generic;
    using System;

    public class SpaceProbe : ISpaceProbe
    {
        public Position Position { get; set; }
        public CardinalDirections Direction { get; set; }
        public IMarsPlateau PlateauLanded { get; set; }
        public Status Status { get; set; }

        public void Move(List<Movements> movements)
        {
            foreach (var move in movements)
            {
                switch (move)
                {
                    case Movements.Left:
                        LeftRotation();
                        break;
                    case Movements.Right:
                        RightRotation();
                        break;
                    case Movements.Forward:
                        MoveForward();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RightRotation() =>
            Direction = Direction == CardinalDirections.West ? CardinalDirections.North : Direction += 1;

        private void LeftRotation() =>
            Direction = Direction == CardinalDirections.North ? CardinalDirections.West : Direction -= 1;

        private void MoveForward()
        {
            var nextPosition = new Position(Position.XAxis, Position.YAxis);
            switch (Direction)
            {
                case CardinalDirections.North:
                    nextPosition.YAxis++;
                    break;
                case CardinalDirections.East:
                    nextPosition.XAxis++;
                    break;
                case CardinalDirections.South:
                    nextPosition.YAxis--;
                    break;
                case CardinalDirections.West:
                    nextPosition.XAxis--;
                    break;
                default:
                    break;
            }
            if (IsValidPlateauPosition(PlateauLanded, nextPosition))
                Position = nextPosition;
            else
                throw new InvalidOperationException("Invalid Move Location!");
        }

        public void Land(IMarsPlateau plateau, Position position, CardinalDirections direction)
        {
            if (IsValidPlateauPosition(plateau, position))
            {
                Position = position;
                Direction = direction;
                PlateauLanded = plateau;
                Status = Status.Landed;
            }
        }

        public bool IsValidPlateauPosition(IMarsPlateau plateau, Position position)
        {
            return position.XAxis <= plateau.Size.Width && position.YAxis <= plateau.Size.Height;
        }

        public string Location()
        {
            return string.Format(@"{0} {1} {2}", Position.XAxis, Position.YAxis, Direction.ToString().Substring(0,1));
        }
    }
}
