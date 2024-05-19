using System.IO;


namespace Smajlici
{
    public class Puzzle
    {
        public static List<Image> usedImages = new List<Image>();
        public static List<Image> usedImagesLeft = new List<Image>();
        public static List<Image> usedImagesTop = new List<Image>();
        public static List<Image> usedImagesRight = new List<Image>();
        public static List<Image> usedImagesBottom = new List<Image>();
        public static List<Image> imagesLeft = new List<Image>();
        public static List<Image> imagesTop = new List<Image>();
        public static List<Image> imagesRight = new List<Image>();
        public static List<Image> imagesBottom = new List<Image>();
        public static Image[,] imageGrid = new Image[3, 3];

        public Smiley centerLeftSmiley;
        public Smiley centerTopSmiley;
        public Smiley centerRightSmiley;
        public Smiley centerBottomSmiley;

        public readonly string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");


        public bool FindImages()
        {
            if (Directory.Exists(imagesPath))
            {
                foreach (var imagePath in Directory.GetFiles(imagesPath))
                {
                    Image obrazek = new Image(Path.GetFileNameWithoutExtension(imagePath));
                }
                return true;
            }
            return false;
        }

        public void FindPossibleNeighbords()
        {
            ClearGrid();

            foreach (var image in Image.images)
            {
                ClearLists();
                imageGrid[1, 1] = image; // Set center image


                foreach (var smiley in image.Smileys)
                {
                    switch (smiley.Position)
                    {
                        case "left":
                            imagesLeft = FindImages(smiley.Color, smiley.Shape);
                            centerLeftSmiley = new Smiley();
                            centerLeftSmiley.Color = smiley.Color;
                            centerLeftSmiley.Shape = smiley.Shape;
                            break;

                        case "top":
                            imagesTop = FindImages(smiley.Color, smiley.Shape);
                            centerTopSmiley = new Smiley();
                            centerTopSmiley.Color = smiley.Color;
                            centerTopSmiley.Shape = smiley.Shape;
                            break;

                        case "right":
                            imagesRight = FindImages(smiley.Color, smiley.Shape);
                            centerRightSmiley = new Smiley();
                            centerRightSmiley.Color = smiley.Color;
                            centerRightSmiley.Shape = smiley.Shape;
                            break;

                        case "bottom":
                            imagesBottom = FindImages(smiley.Color, smiley.Shape);
                            centerBottomSmiley = new Smiley();
                            centerBottomSmiley.Color = smiley.Color;
                            centerBottomSmiley.Shape = smiley.Shape;
                            break;
                    }
                }

                imagesLeft.Remove(image);
                imagesTop.Remove(image);
                imagesRight.Remove(image);
                imagesBottom.Remove(image);

                usedImagesBottom.Clear();
                usedImagesLeft.Clear();
                usedImagesRight.Clear();
                usedImagesTop.Clear();

                if (SolvePuzzleCenter()) { break; }
            }
        }

        private bool SolvePuzzleCenter()
        {
            ClearUsedImages();

            foreach (var image in imagesLeft)
            {
                if (!usedImages.Contains(image) & (!usedImagesLeft.Contains(image)))
                {
                    imageGrid[1, 0] = image;
                    usedImages.Add(image);
                    usedImagesLeft.Add(image);
                    RotateImages(image, "right");
                    break;
                }
            }
            foreach (var image in imagesTop)
            {
                if (!usedImages.Contains(image) & (!usedImagesTop.Contains(image)))
                {
                    imageGrid[0, 1] = image;
                    usedImages.Add(image);
                    usedImagesTop.Add(image);
                    RotateImages(image, "bottom");
                    break;

                }
            }
            foreach (var image in imagesRight)
            {
                if (!usedImages.Contains(image) & (!usedImagesRight.Contains(image)))
                {
                    imageGrid[1, 2] = image;
                    usedImages.Add(image);
                    usedImagesRight.Add(image);
                    RotateImages(image, "left");
                    break;

                }
            }
            foreach (var image in imagesBottom)
            {
                if (!usedImages.Contains(image) & (!usedImagesBottom.Contains(image)))
                {
                    imageGrid[2, 1] = image;
                    usedImages.Add(image);
                    usedImagesBottom.Add(image);
                    RotateImages(image, "top");
                    break;

                }
            }
            return false;
        }




        public bool IsValid()
        {


            return false;
        }









        public void RotateImages(Image image, string targetPosition)
        {
            foreach (var smiley in image.Smileys)
            {
                if (targetPosition == "left")
                {
                    if ((smiley.Color == centerRightSmiley.Color) & (smiley.Shape != centerRightSmiley.Shape))
                    {
                        while (smiley.Position != targetPosition)
                        {
                            image.RotateClockwise(image);
                        }
                    }
                }

                if (targetPosition == "top")
                {
                    if ((smiley.Color == centerBottomSmiley.Color) & (smiley.Shape != centerBottomSmiley.Shape))
                    {
                        while (smiley.Position != targetPosition)
                        {
                            image.RotateClockwise(image);
                        }
                    }
                }


                if (targetPosition == "right")
                {
                    if ((smiley.Color == centerLeftSmiley.Color) & (smiley.Shape != centerLeftSmiley.Shape))
                    {
                        while (smiley.Position != targetPosition)
                        {
                            image.RotateClockwise(image);
                        }
                    }
                }

                if (targetPosition == "bottom")
                {
                    if ((smiley.Color == centerTopSmiley.Color) & (smiley.Shape != centerTopSmiley.Shape))
                    {
                        while (smiley.Position != targetPosition)
                        {
                            image.RotateClockwise(image);
                        }
                    }
                }
            }

        }


        public static List<Image> FindImages(string color, string shape)
        {
            List<Image> result = new List<Image>();

            foreach (var image in Image.images)
            {
                foreach (var smiley in image.Smileys)
                {
                    if (smiley.Color == color && smiley.Shape != shape)
                    {
                        result.Add(image);

                    }
                }
            }
            return result;
        }




        public void ClearGrid()
        {
            Array.Clear(imageGrid, 0, imageGrid.Length);
        }

        public void ClearLists()
        {
            imagesLeft.Clear();
            imagesTop.Clear();
            imagesRight.Clear();
            imagesBottom.Clear();
        }

        public void ClearUsedImages()
        {
            usedImages.Clear();

        }


    }
}

