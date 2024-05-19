using System.IO;


namespace Smajlici
{
    public class Puzzle
    {
        public static List<Image> usedImages = new List<Image>();
        public static Image[,] imageGrid = new Image[3, 3];



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
                imageGrid[0, 0] = image; // Set starting image at (0, 0)

                if (SolvePuzzleBacktracking(0, 0))
                {
                    break;
                }
            }
        }

        private bool SolvePuzzleBacktracking(int row, int col)
        {
            if (row == 3)
            {
                return true; // Pokud jsme prošli všechny řádky, puzzle je vyřešené
            }

            // Příští pozice
            int nextRow = (col == 2) ? row + 1 : row;
            int nextCol = (col == 2) ? 0 : col + 1;

            foreach (var image in Image.images)
            {
                if (!usedImages.Contains(image))
                {
                    usedImages.Add(image);

                    for (int i = 0; i < 4; i++) // Vyzkoušíme všechny čtyři rotace
                    {
                        image.RotateClockwise(); // Otočíme obrázek
                        imageGrid[row, col] = image;

                        if (IsValid(row, col) && SolvePuzzleBacktracking(nextRow, nextCol))
                        {
                            return true;
                        }
                    }

                    usedImages.Remove(image);
                    imageGrid[row, col] = null;
                }
            }

            return false;
        }

        private bool IsValid(int row, int col)
        {
            var image = imageGrid[row, col];

            // Ověřování sousedů
            if (row > 0 && imageGrid[row - 1, col] != null) // Ověřujeme obrázek nahoře
            {
                if (!Matches(image, imageGrid[row - 1, col], "top"))
                {
                    return false;
                }
            }
            if (row < 2 && imageGrid[row + 1, col] != null) // Ověřujeme obrázek dole
            {
                if (!Matches(image, imageGrid[row + 1, col], "bottom"))
                {
                    return false;
                }
            }
            if (col > 0 && imageGrid[row, col - 1] != null) // Ověřujeme obrázek vlevo
            {
                if (!Matches(image, imageGrid[row, col - 1], "left"))
                {
                    return false;
                }
            }
            if (col < 2 && imageGrid[row, col + 1] != null) // Ověřujeme obrázek vpravo
            {
                if (!Matches(image, imageGrid[row, col + 1], "right"))
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
                    return currentImage.GetSmiley("top").CompareTwoSmiley(neighborImage.GetSmiley("bottom"));
                case "bottom":
                    return currentImage.GetSmiley("bottom").CompareTwoSmiley(neighborImage.GetSmiley("top"));
                case "left":
                    return currentImage.GetSmiley("left").CompareTwoSmiley(neighborImage.GetSmiley("right"));
                case "right":
                    return currentImage.GetSmiley("right").CompareTwoSmiley(neighborImage.GetSmiley("left"));
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

