using System;

namespace toDo4
{
    class PhotoBookTest
    {
        static void Main(string[] args)
        {
            PhotoBook photoBook = new PhotoBook();
            Console.WriteLine(photoBook.GetNumberPages());
            Console.WriteLine();

            PhotoBook photoBook2 = new PhotoBook(24);
            Console.WriteLine(photoBook2.GetNumberPages());
            Console.WriteLine();

            BigPhotoBook bigPhotoBook = new BigPhotoBook();
            Console.WriteLine(bigPhotoBook.GetNumberPages());
        }
    }

    public class PhotoBook
    {
        protected int numPages;

        public PhotoBook()
        {
            numPages = 16;
        }

        public PhotoBook(int numPages)
        {
            this.numPages = numPages;
        }

        public int GetNumberPages()
        {
            return numPages;
        }
    }

    public class BigPhotoBook : PhotoBook
    {
        public BigPhotoBook()
        {
            numPages = 64;
        }
    }
}
