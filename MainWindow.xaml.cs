using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Smajlici
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void SolvePuzzleButton_Click(object sender, RoutedEventArgs e)
        {
            Puzzle puzzle = new Puzzle();

            if (puzzle.FindImages())
            {
                puzzle.FindPossibleNeighbords();
                //AlignImages();
                PrintImageGridNames();
            }

        }

        private void AlignImages()
        {
            image1A.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[0, 0].Name}.png", UriKind.Relative));
            image1B.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[0, 1].Name}.png", UriKind.Relative));
            image1C.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[0, 2].Name}.png", UriKind.Relative));
            image2A.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[1, 0].Name}.png", UriKind.Relative));
            image2B.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[1, 1].Name}.png", UriKind.Relative));
            image2C.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[1, 2].Name}.png", UriKind.Relative));
            image3A.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[2, 0].Name}.png", UriKind.Relative));
            image3B.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[2, 1].Name}.png", UriKind.Relative));
            image3C.Source = new BitmapImage(new Uri($"/Images/{Puzzle.imageGrid[2, 2].Name}.png", UriKind.Relative));

            RotateTransform rotateTransform = new RotateTransform(Puzzle.imageGrid[0, 0].Rotation);
            image1A.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[0, 1].Rotation);
            image1B.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[0, 2].Rotation);
            image1C.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[1, 0].Rotation);
            image2A.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[1, 1].Rotation);
            image2B.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[1, 2].Rotation);
            image2C.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[2, 0].Rotation);
            image3A.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[2, 1].Rotation);
            image3B.RenderTransform = rotateTransform;

            rotateTransform = new RotateTransform(Puzzle.imageGrid[2, 2].Rotation);
            image3C.RenderTransform = rotateTransform;
        }


        public void PrintImageGridNames()
        {
            for (int i = 0; i < Puzzle.imageGrid.GetLength(0); i++)
            {
                for (int j = 0; j < Puzzle.imageGrid.GetLength(1); j++)
                {
                    Console.WriteLine(Puzzle.imageGrid[i, j].Name);
                }
            }
        }


    }
}

