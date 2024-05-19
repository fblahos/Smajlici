namespace Smajlici
{
    public class Smiley
    {
        public string Color { get; set; }
        public string Position { get; set; }
        public string Shape { get; set; }

        public void RotateClockwise()
        {
            switch (Position)
            {
                case "top":
                    Position = "right";
                    break;
                case "right":
                    Position = "bottom";
                    break;
                case "bottom":
                    Position = "left";
                    break;
                case "left":
                    Position = "top";
                    break;
            }
        }

        public bool CompareTwoSmiley(Smiley smileyB)
        {
            return this.Color == smileyB.Color && this.Shape != smileyB.Shape;
        }
    }
}
