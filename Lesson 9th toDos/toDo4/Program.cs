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
}
