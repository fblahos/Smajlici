using System.Windows;
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
                puzzle.SolvePuzzle();
                AlignImages();
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


            rotateTransform1A.Angle = Puzzle.imageGrid[0, 0].Rotation;
            rotateTransform1B.Angle = Puzzle.imageGrid[0, 1].Rotation;
            rotateTransform1C.Angle = Puzzle.imageGrid[0, 2].Rotation;
            rotateTransform2A.Angle = Puzzle.imageGrid[1, 0].Rotation;
            rotateTransform2B.Angle = Puzzle.imageGrid[1, 1].Rotation;
            rotateTransform2C.Angle = Puzzle.imageGrid[1, 2].Rotation;
            rotateTransform3A.Angle = Puzzle.imageGrid[2, 0].Rotation;
            rotateTransform3B.Angle = Puzzle.imageGrid[2, 1].Rotation;
            rotateTransform3C.Angle = Puzzle.imageGrid[2, 2].Rotation;
        }




    }
}

