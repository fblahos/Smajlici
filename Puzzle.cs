using System.IO;


namespace Smajlici
{
    public class Puzzle
    {
        private static List<Image> usedImages = new List<Image>();
        public static Image[,] imageGrid = new Image[3, 3];
        private readonly string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");


        public bool FindImages()
        {
            if (Directory.Exists(imagesPath))
            {
                foreach (var imagePath in Directory.GetFiles(imagesPath))
                {
                    Image image = new Image(Path.GetFileNameWithoutExtension(imagePath));
                }
                return true;
            }
            return false;
        }


        public void SolvePuzzle()
        {
            ClearGrid();

            //Postupně všechny obrázky umístím na souřadnice 0,0
            foreach (var image in Image.images)
            {
                imageGrid[0, 0] = image;

                if (PuzzleBacktracking(0, 0))
                {
                    break;
                }
            }
        }

        private bool PuzzleBacktracking(int row, int column)
        {
            //Pokud je řádek větší než 2 tak je puzzle vyřešeno
            if (row > 2)
            {
                return true;
            }

            int nextRow = (column == 2) ? row + 1 : row;
            int nextColumn = (column == 2) ? nextColumn = 0 : nextColumn = column + 1;


            foreach (var image in Image.images)
            {
                if (!usedImages.Contains(image))
                {
                    usedImages.Add(image);

                    for (int i = 0; i < 4; i++)
                    {
                        image.RotateClockwise();
                        imageGrid[row, column] = image;

                        if (IsValid(row, column) && PuzzleBacktracking(nextRow, nextColumn))
                        {
                            return true;
                        }
                    }

                    usedImages.Remove(image);
                    imageGrid[row, column] = null;
                }
            }

            return false;
        }

        private bool IsValid(int row, int column)
        {
            var image = imageGrid[row, column];

            // Ověřování sousedů
            if (row > 0 && imageGrid[row - 1, column] != null)
            {
                if (!Matches(image, imageGrid[row - 1, column], "top"))
                {
                    return false;
                }
            }
            if (row < 2 && imageGrid[row + 1, column] != null)
            {
                if (!Matches(image, imageGrid[row + 1, column], "bottom"))
                {
                    return false;
                }
            }
            if (column > 0 && imageGrid[row, column - 1] != null)
            {
                if (!Matches(image, imageGrid[row, column - 1], "left"))
                {
                    return false;
                }
            }
            if (column < 2 && imageGrid[row, column + 1] != null)
            {
                if (!Matches(image, imageGrid[row, column + 1], "right"))
                {
                    return false;
                }
            }

            return true;
        }

        private bool Matches(Image currentImage, Image neighborImage, string direction)
        {
            switch (direction)
            {
                case "top":
                    return currentImage.GetSmiley("top").CompareSmileys(neighborImage.GetSmiley("bottom"));
                case "bottom":
                    return currentImage.GetSmiley("bottom").CompareSmileys(neighborImage.GetSmiley("top"));
                case "left":
                    return currentImage.GetSmiley("left").CompareSmileys(neighborImage.GetSmiley("right"));
                case "right":
                    return currentImage.GetSmiley("right").CompareSmileys(neighborImage.GetSmiley("left"));
                default:
                    throw new ArgumentException("Neplatný směr ověření.");
            }
        }


        public void ClearGrid()
        {
            Array.Clear(imageGrid, 0, imageGrid.Length);
        }






    }
}

