namespace Smajlici
{
    public class Image
    {

        public static List<Image> images = new List<Image>();
        public string Name { get; set; }
        public int Rotation { get; set; }

        public List<Smiley> Smileys { get; set; }

        public Image(string name)
        {
            Name = name;
            Rotation = 0;
            GetSmileys(name);
            images.Add(this);
        }

        public void GetSmileys(string name)
        {
            Smileys = new List<Smiley>();

            switch (name.ToLower())
            {
                case "1a":
                    Smileys.Add(new Smiley { Color = "green", Shape = "eyes", Position = "left" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "top" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "smile", Position = "right" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "eyes", Position = "bottom" });
                    break;
                case "1b":
                    Smileys.Add(new Smiley { Color = "green", Shape = "smile", Position = "left" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "eyes", Position = "top" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "eyes", Position = "right" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "smile", Position = "bottom" });
                    break;
                case "1c":
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "smile", Position = "left" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "eyes", Position = "top" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "eyes", Position = "right" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "smile", Position = "bottom" });
                    break;
                case "2a":
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "left" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "top" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "eyes", Position = "right" });
                    Smileys.Add(new Smiley { Color = "green", Shape = "eyes", Position = "bottom" });
                    break;
                case "2b":
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "smile", Position = "left" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "eyes", Position = "top" });
                    Smileys.Add(new Smiley { Color = "green", Shape = "eyes", Position = "right" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "bottom" });
                    break;
                case "2c":
                    Smileys.Add(new Smiley { Color = "green", Shape = "eyes", Position = "left" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "smile", Position = "top" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "smile", Position = "right" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "eyes", Position = "bottom" });
                    break;
                case "3a":
                    Smileys.Add(new Smiley { Color = "blue", Shape = "eyes", Position = "left" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "smile", Position = "top" });
                    Smileys.Add(new Smiley { Color = "green", Shape = "smile", Position = "right" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "eyes", Position = "bottom" });
                    break;
                case "3b":
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "eyes", Position = "left" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "eyes", Position = "top" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "right" });
                    Smileys.Add(new Smiley { Color = "blue", Shape = "smile", Position = "bottom" });
                    break;
                case "3c":
                    Smileys.Add(new Smiley { Color = "green", Shape = "eyes", Position = "left" });
                    Smileys.Add(new Smiley { Color = "yellow", Shape = "eyes", Position = "top" });
                    Smileys.Add(new Smiley { Color = "red", Shape = "smile", Position = "right" });
                    Smileys.Add(new Smiley { Color = "green", Shape = "smile", Position = "bottom" });
                    break;
            }

        }


        public void RotateClockwise(Image image)
        {
            foreach (var smiley in image.Smileys)
            {
                switch (smiley.Position)
                {
                    case "left":
                        smiley.Position = "top";
                        break;
                    case "top":
                        smiley.Position = "right";
                        break;
                    case "right":
                        smiley.Position = "bottom";
                        break;
                    case "bottom":
                        smiley.Position = "left";
                        break;
                }
            }

            image.Rotation = (image.Rotation + 90) % 360;
        }


    }
}

