using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Başlatılıyor...");
            string resimKonum = "C:\Resim.jpg";
            Image resim = Image.FromFile(resimKonum);
            int kare = 160;

            Console.WriteLine(string.Format("Resim Ölçüleri Genişlik={0}px Yükseklik={1}px", resim.Width, resim.Height));

            if (resim.Height % kare != 0 || resim.Width % kare != 0)
            {
                string gecerliOlculer = OrtakKatlar(resim.Height, resim.Width);
                Console.WriteLine(string.Format( kare, gecerliOlculer));
                Console.ReadKey();
                return;
            }

            int xParca = resim.Height / kare;
            int yParca = resim.Width / kare;
            Rectangle cropAlani = new Rectangle(0, 0, kare, kare);

            Directory.CreateDirectory(@"C:\Resim.jpg");

            for (int d = 0; d < xParca; d++)
            {
                for (int y = 0; y < yParca; y++)
                {
                    cropAlani.Y = d * kare;

                    cropAlani.X = y * kare;
                    Image parcaResim = Crop(resim, cropAlani);
                    parcaResim.Save(@"C:\resimler\" + d + "x" + y + ".jpg", ImageFormat.Jpeg);
                }
            }

            Console.WriteLine(String.Format( kare.ToString() + "x" + kare.ToString(), xparca * yatParca));
            Console.Write("\nişlem bitti bir tuşa basın...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadKey();
        }
    }

    private static Image Crop(Image image, Rectangle rect)
    {
        Bitmap resim = new Bitmap(image);
        Bitmap parcaResim = resim.Clone(rect, resim.PixelFormat);

        return (Image)(parcaResim);
    }

    private static string OrtakKatlar(int sayi1, int sayi2)
    {
        int kSayi = Math.Min(sayi1, sayi2);
        string ortak = "";

        for (int i = 2; i <= kSayi; i++)
        {
            if (sayi1 % i == 0 && sayi2 % i == 0)
                ortak += i.ToString() + ",";
        }

        ortak = ortak.Remove(ortak.Length - 1);

        return ortak;
    }
}
