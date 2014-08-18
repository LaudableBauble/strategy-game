using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EUIV_ModHelper
{
    public static class Helper
    {
        static string ROOT = @"C:\Users\Sebastian\Desktop\html5\3DMap_Test\";
        //static string ROOT = @"C:\Users\swibbe\Desktop\html5\3DMap_Test\";

        public enum TerrainType
        {
            PTI, Ocean, Inland_Ocean, Arctic, Farmlands, Forest,
            Hills, Woods, Mountain, Desert_Mountain, Impassable_Mountains,
            Grasslands, Plains, Jungle, Marsh, Desert, Coastal_Desert, Coastline
        }
        public enum TerrainCategoriesEU3
        {
            Arctic_1, Arctic_2, Arctic_3, Arctic_4,
            Plains_1, Plains_2, Plains_3, Plains_4,
            Farmlands_1, Farmlands_2, Farmlands_3, Farmlands_4,
            Forest_1, Forest_2, Forest_3, Forest_4,
            Hills_1, Hills_2, Hills_3, Hills_4,
            Woods_1, Woods_2, Woods_3, Woods_4,
            Mountain_1, Mountain_2, Mountain_3, Mountain_4,
            Mountain_5, Mountain_6, Mountain_7, Mountain_8,
            Plains_5, Plains_6, Plains_7, Plains_8,
            Steppe_1, Steppe_2, Steppe_3, Steppe_4,
            Jungle_1, Jungle_2, Jungle_3, Jungle_4,
            Marsh_1, Marsh_2, Marsh_3, Marsh_4,
            Desert_1, Desert_2, Desert_3, Desert_4,
            Coastal_Desert_1, Coastal_Desert_2, Coastal_Desert_3, Coastal_Desert_4,
            Inland_Ocean1 = 253, Ocean1 = 254
        }
        public enum TerrainCategoriesEU4
        {
            Plains, Hills, Desert_Mountain, Desert, Grasslands, Terrain_5, Mountain, Desert_Mountain_Low,
            Terrain_8, Marsh, Terrain_10, Terrain_11, Forest_12, Forest_13, Forest_14, Ocean, Snow,
            Inland_Ocean_17, Coastal_Desert_18 = 19, Coastline = 35, Woods = 253, Jungle = 254
        }

        public static int GetHeight(TerrainCategoriesEU3 tc)
        {
            switch (tc)
            {
                case TerrainCategoriesEU3.Arctic_1: { return 98; }
                case TerrainCategoriesEU3.Arctic_2: { return 98; }
                case TerrainCategoriesEU3.Arctic_3: { return 98; }
                case TerrainCategoriesEU3.Arctic_4: { return 98; }
                case TerrainCategoriesEU3.Plains_1: { return 98; }
                case TerrainCategoriesEU3.Plains_2: { return 98; }
                case TerrainCategoriesEU3.Plains_3: { return 98; }
                case TerrainCategoriesEU3.Plains_4: { return 98; }
                case TerrainCategoriesEU3.Farmlands_1: { return 98; }
                case TerrainCategoriesEU3.Farmlands_2: { return 98; }
                case TerrainCategoriesEU3.Farmlands_3: { return 98; }
                case TerrainCategoriesEU3.Farmlands_4: { return 98; }
                case TerrainCategoriesEU3.Forest_1: { return 98; }
                case TerrainCategoriesEU3.Forest_2: { return 98; }
                case TerrainCategoriesEU3.Forest_3: { return 98; }
                case TerrainCategoriesEU3.Forest_4: { return 98; }
                case TerrainCategoriesEU3.Hills_1: { return 120; }
                case TerrainCategoriesEU3.Hills_2: { return 140; }
                case TerrainCategoriesEU3.Hills_3: { return 160; }
                case TerrainCategoriesEU3.Hills_4: { return 180; }
                case TerrainCategoriesEU3.Woods_1: { return 98; }
                case TerrainCategoriesEU3.Woods_2: { return 98; }
                case TerrainCategoriesEU3.Woods_3: { return 98; }
                case TerrainCategoriesEU3.Woods_4: { return 98; }
                case TerrainCategoriesEU3.Mountain_1: { return 200; }
                case TerrainCategoriesEU3.Mountain_2: { return 220; }
                case TerrainCategoriesEU3.Mountain_3: { return 230; }
                case TerrainCategoriesEU3.Mountain_4: { return 240; }
                case TerrainCategoriesEU3.Mountain_5: { return 250; }
                case TerrainCategoriesEU3.Mountain_6: { return 220; }
                case TerrainCategoriesEU3.Mountain_7: { return 220; }
                case TerrainCategoriesEU3.Mountain_8: { return 220; }
                case TerrainCategoriesEU3.Plains_5: { return 98; }
                case TerrainCategoriesEU3.Plains_6: { return 98; }
                case TerrainCategoriesEU3.Plains_7: { return 98; }
                case TerrainCategoriesEU3.Plains_8: { return 98; }
                case TerrainCategoriesEU3.Steppe_1: { return 98; }
                case TerrainCategoriesEU3.Steppe_2: { return 98; }
                case TerrainCategoriesEU3.Steppe_3: { return 98; }
                case TerrainCategoriesEU3.Steppe_4: { return 98; }
                case TerrainCategoriesEU3.Jungle_1: { return 98; }
                case TerrainCategoriesEU3.Jungle_2: { return 98; }
                case TerrainCategoriesEU3.Jungle_3: { return 98; }
                case TerrainCategoriesEU3.Jungle_4: { return 98; }
                case TerrainCategoriesEU3.Marsh_1: { return 98; }
                case TerrainCategoriesEU3.Marsh_2: { return 98; }
                case TerrainCategoriesEU3.Marsh_3: { return 98; }
                case TerrainCategoriesEU3.Marsh_4: { return 98; }
                case TerrainCategoriesEU3.Desert_1: { return 98; }
                case TerrainCategoriesEU3.Desert_2: { return 98; }
                case TerrainCategoriesEU3.Desert_3: { return 98; }
                case TerrainCategoriesEU3.Desert_4: { return 98; }
                case TerrainCategoriesEU3.Coastal_Desert_1: { return 98; }
                case TerrainCategoriesEU3.Coastal_Desert_2: { return 98; }
                case TerrainCategoriesEU3.Coastal_Desert_3: { return 98; }
                case TerrainCategoriesEU3.Coastal_Desert_4: { return 98; }
                case TerrainCategoriesEU3.Ocean1: { return 60; }
                case TerrainCategoriesEU3.Inland_Ocean1: { return 80; }
                default: { return 98; }
            }
        }
        public static TerrainType GetTerrainType(TerrainCategoriesEU3 tc)
        {
            switch (tc)
            {
                case TerrainCategoriesEU3.Arctic_1: { return TerrainType.Arctic; }
                case TerrainCategoriesEU3.Arctic_2: { return TerrainType.Arctic; }
                case TerrainCategoriesEU3.Arctic_3: { return TerrainType.Arctic; }
                case TerrainCategoriesEU3.Arctic_4: { return TerrainType.Arctic; }
                case TerrainCategoriesEU3.Plains_1: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_2: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_3: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_4: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Farmlands_1: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU3.Farmlands_2: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU3.Farmlands_3: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU3.Farmlands_4: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU3.Forest_1: { return TerrainType.Forest; }
                case TerrainCategoriesEU3.Forest_2: { return TerrainType.Forest; }
                case TerrainCategoriesEU3.Forest_3: { return TerrainType.Forest; }
                case TerrainCategoriesEU3.Forest_4: { return TerrainType.Forest; }
                case TerrainCategoriesEU3.Hills_1: { return TerrainType.Hills; }
                case TerrainCategoriesEU3.Hills_2: { return TerrainType.Hills; }
                case TerrainCategoriesEU3.Hills_3: { return TerrainType.Hills; }
                case TerrainCategoriesEU3.Hills_4: { return TerrainType.Hills; }
                case TerrainCategoriesEU3.Woods_1: { return TerrainType.Woods; }
                case TerrainCategoriesEU3.Woods_2: { return TerrainType.Woods; }
                case TerrainCategoriesEU3.Woods_3: { return TerrainType.Woods; }
                case TerrainCategoriesEU3.Woods_4: { return TerrainType.Woods; }
                case TerrainCategoriesEU3.Mountain_1: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_2: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_3: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_4: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_5: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_6: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_7: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Mountain_8: { return TerrainType.Mountain; }
                case TerrainCategoriesEU3.Plains_5: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_6: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_7: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Plains_8: { return TerrainType.Plains; }
                case TerrainCategoriesEU3.Steppe_1: { return TerrainType.Grasslands; }
                case TerrainCategoriesEU3.Steppe_2: { return TerrainType.Grasslands; }
                case TerrainCategoriesEU3.Steppe_3: { return TerrainType.Grasslands; }
                case TerrainCategoriesEU3.Steppe_4: { return TerrainType.Grasslands; }
                case TerrainCategoriesEU3.Jungle_1: { return TerrainType.Jungle; }
                case TerrainCategoriesEU3.Jungle_2: { return TerrainType.Jungle; }
                case TerrainCategoriesEU3.Jungle_3: { return TerrainType.Jungle; }
                case TerrainCategoriesEU3.Jungle_4: { return TerrainType.Jungle; }
                case TerrainCategoriesEU3.Marsh_1: { return TerrainType.Marsh; }
                case TerrainCategoriesEU3.Marsh_2: { return TerrainType.Marsh; }
                case TerrainCategoriesEU3.Marsh_3: { return TerrainType.Marsh; }
                case TerrainCategoriesEU3.Marsh_4: { return TerrainType.Marsh; }
                case TerrainCategoriesEU3.Desert_1: { return TerrainType.Desert; }
                case TerrainCategoriesEU3.Desert_2: { return TerrainType.Desert; }
                case TerrainCategoriesEU3.Desert_3: { return TerrainType.Desert; }
                case TerrainCategoriesEU3.Desert_4: { return TerrainType.Desert; }
                case TerrainCategoriesEU3.Coastal_Desert_1: { return TerrainType.Coastal_Desert; }
                case TerrainCategoriesEU3.Coastal_Desert_2: { return TerrainType.Coastal_Desert; }
                case TerrainCategoriesEU3.Coastal_Desert_3: { return TerrainType.Coastal_Desert; }
                case TerrainCategoriesEU3.Coastal_Desert_4: { return TerrainType.Coastal_Desert; }
                case TerrainCategoriesEU3.Ocean1: { return TerrainType.Ocean; }
                case TerrainCategoriesEU3.Inland_Ocean1: { return TerrainType.Inland_Ocean; }
                default: { return TerrainType.Grasslands; }
            }
        }
        public static TerrainType GetTerrainType(TerrainCategoriesEU4 tc)
        {
            switch (tc)
            {
                case TerrainCategoriesEU4.Plains: { return TerrainType.Plains; }
                case TerrainCategoriesEU4.Hills: { return TerrainType.Hills; }
                case TerrainCategoriesEU4.Desert_Mountain: { return TerrainType.Desert_Mountain; }
                case TerrainCategoriesEU4.Desert: { return TerrainType.Desert; }
                case TerrainCategoriesEU4.Grasslands: { return TerrainType.Grasslands; }
                case TerrainCategoriesEU4.Terrain_5: { return TerrainType.Plains; }
                case TerrainCategoriesEU4.Mountain: { return TerrainType.Mountain; }
                case TerrainCategoriesEU4.Desert_Mountain_Low: { return TerrainType.Desert; }
                case TerrainCategoriesEU4.Terrain_8: { return TerrainType.Hills; }
                case TerrainCategoriesEU4.Marsh: { return TerrainType.Marsh; }
                case TerrainCategoriesEU4.Terrain_10: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU4.Terrain_11: { return TerrainType.Farmlands; }
                case TerrainCategoriesEU4.Forest_12: { return TerrainType.Forest; }
                case TerrainCategoriesEU4.Forest_13: { return TerrainType.Forest; }
                case TerrainCategoriesEU4.Forest_14: { return TerrainType.Forest; }
                case TerrainCategoriesEU4.Ocean: { return TerrainType.Ocean; }
                case TerrainCategoriesEU4.Snow: { return TerrainType.Mountain; }
                case TerrainCategoriesEU4.Inland_Ocean_17: { return TerrainType.Inland_Ocean; }
                case TerrainCategoriesEU4.Coastal_Desert_18: { return TerrainType.Coastal_Desert; }
                case TerrainCategoriesEU4.Coastline: { return TerrainType.Coastline; }
                case TerrainCategoriesEU4.Woods: { return TerrainType.Woods; }
                case TerrainCategoriesEU4.Jungle: { return TerrainType.Jungle; }
                default: { return TerrainType.Grasslands; }
            }
        }
        public static TerrainCategoriesEU4 GetTerrainCategories(TerrainType t)
        {
            switch (t)
            {
                case TerrainType.PTI: { return TerrainCategoriesEU4.Plains; }
                case TerrainType.Ocean: { return TerrainCategoriesEU4.Ocean; }
                case TerrainType.Inland_Ocean: { return TerrainCategoriesEU4.Inland_Ocean_17; }
                case TerrainType.Arctic: { return TerrainCategoriesEU4.Snow; }
                case TerrainType.Farmlands: { return TerrainCategoriesEU4.Terrain_10; }
                case TerrainType.Forest: { return TerrainCategoriesEU4.Forest_12; }
                case TerrainType.Hills: { return TerrainCategoriesEU4.Hills; }
                case TerrainType.Woods: { return TerrainCategoriesEU4.Woods; }
                case TerrainType.Mountain: { return TerrainCategoriesEU4.Mountain; }
                case TerrainType.Desert_Mountain: { return TerrainCategoriesEU4.Desert_Mountain; }
                case TerrainType.Impassable_Mountains: { return TerrainCategoriesEU4.Mountain; }
                case TerrainType.Grasslands: { return TerrainCategoriesEU4.Grasslands; }
                case TerrainType.Plains: { return TerrainCategoriesEU4.Plains; }
                case TerrainType.Jungle: { return TerrainCategoriesEU4.Jungle; }
                case TerrainType.Marsh: { return TerrainCategoriesEU4.Marsh; }
                case TerrainType.Desert: { return TerrainCategoriesEU4.Desert; }
                case TerrainType.Coastal_Desert: { return TerrainCategoriesEU4.Coastal_Desert_18; }
                case TerrainType.Coastline: { return TerrainCategoriesEU4.Coastline; }
                default: { return TerrainCategoriesEU4.Grasslands; }
            }
        }
        public static string[] LoadProvinceNames()
        {
            return File.ReadAllLines(ROOT + "names.txt");
        }
        public static void SaveFile(string name, string content)
        {
            File.WriteAllText(ROOT + name + ".txt", content);
        }
        public static string LoadFile(string name)
        {
            var s = File.OpenText(ROOT + name + ".txt");
            var c = s.ReadToEnd();
            s.Close();
            return c;
        }
        public static string LoadDefaultProvince()
        {
            return File.ReadAllText(ROOT + "default.txt");
        }
        public static bool IsCoastPixel(int x, int y, LockBitmap bmp, bool[] matchData)
        {
            //Color to look out for.
            Color sea = Color.FromArgb(0, 32, 128);

            if (IsEqual(x, y, bmp, matchData, sea) || x == 0 || y == 0 || x == bmp.Width - 1 || y == bmp.Height - 1) { return false; }

            bool nw = IsEqual(x - 1, y - 1, bmp, matchData, sea);
            if (nw) { return true; }
            bool n = IsEqual(x, y - 1, bmp, matchData, sea);
            if (n) { return true; }
            bool ne = IsEqual(x + 1, y - 1, bmp, matchData, sea);
            if (ne) { return true; }
            bool e = IsEqual(x + 1, y, bmp, matchData, sea);
            if (e) { return true; }
            bool se = IsEqual(x + 1, y + 1, bmp, matchData, sea);
            if (se) { return true; }
            bool s = IsEqual(x, y + 1, bmp, matchData, sea);
            if (s) { return true; }
            bool sw = IsEqual(x - 1, y + 1, bmp, matchData, sea);
            if (sw) { return true; }
            bool w = IsEqual(x - 1, y, bmp, matchData, sea);
            if (w) { return true; }

            return false;
        }
        public static bool IsEqual(int x, int y, LockBitmap bmp, bool[] matchData, Color color)
        {
            if (matchData[bmp.Width * y + x]) { return true; }
            bool b = bmp.GetPixel(x, y).Equals(color);
            if (b) { matchData[bmp.Width * y + x] = true; }
            return b;
        }
        public static Bitmap LoadImage(string path)
        {
            return (Bitmap)Image.FromFile(ROOT + path);

            //return img.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public static void SaveImage(Bitmap img, string path)
        {
            //img = img.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            img.Save(ROOT + path, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        public static void PaintCoast()
        {
            Bitmap img = LoadImage("terrain.bmp");
            var p = img.Palette;
            p.Entries[10] = Color.FromArgb(255, 247, 0);
            img.Palette = p;
            LockBitmap lockImg = new LockBitmap(img);
            lockImg.LockBits();
            int pixelsPainted = 0;
            bool[] matchData = new bool[lockImg.Width * lockImg.Height];

            for (int y = 0; y < lockImg.Height; y++)
            {
                for (int x = 0; x < lockImg.Width; x++)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Checking pixel (" + x + ", " + y + ")");
                    if (IsCoastPixel(x, y, lockImg, matchData))
                    {
                        lockImg.SetPixel(x, y, Color.FromArgb(255, 247, 0));
                        pixelsPainted++;
                        Console.WriteLine("Pixels Painted: " + pixelsPainted);
                    }
                }
            }

            lockImg.UnlockBits();
            SaveImage(img, "terrain_coast.bmp");
        }
        public static void ConvertToEU4Terrain()
        {
            Bitmap img = LoadImage("terrain_eu3.bmp");
            Bitmap img2 = LoadImage("terrain_eu4.bmp");
            Bitmap table = LoadImage("terrain_eu3_colortable.bmp");
            var p = table.Palette;
            var tablePalette = new Dictionary<Color, int>();
            for (int i = 0; i < p.Entries.Length; i++)
            {
                if (!tablePalette.ContainsKey(p.Entries[i])) { tablePalette.Add(p.Entries[i], i); }
            }
            var p2 = img2.Palette;
            //p.Entries[10] = Color.FromArgb(255, 247, 0);
            //img.Palette = p;
            LockBitmap lockImg = new LockBitmap(img);
            LockBitmap lockImg2 = new LockBitmap(img2);
            lockImg.LockBits();
            lockImg2.LockBits();

            for (int y = 0; y < lockImg.Height; y++)
            {
                for (int x = 0; x < lockImg.Width; x++)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("At pixel (" + x + ", " + y + ")");
                    var c = lockImg.GetPixel(x, y);
                    int indexIn = tablePalette.ContainsKey(c) ? tablePalette[lockImg.GetPixel(x, y)] : 0;
                    int indexOut = (int)GetTerrainCategories(GetTerrainType((TerrainCategoriesEU3)indexIn));
                    //var color = p2.Entries[indexOut];
                    lockImg2.SetPixelIndex(x, y, indexOut);
                }
            }

            lockImg.UnlockBits();
            lockImg2.UnlockBits();
            SaveImage(img2, "terrain_converted.bmp");
        }
        public static void PrintColorIndex(Color color)
        {
            Bitmap table = LoadImage("terrain_eu3_colortable.bmp");
            var p = table.Palette;
            Console.WriteLine("The color " + color.ToString() + " has index " + p.Entries.ToList().IndexOf(color));
            Console.ReadLine();
        }
        public static void PaintHeightmap()
        {
            Bitmap terrain = LoadImage("terrain_eu3.bmp");
            Bitmap heightmap = LoadImage("heightmap.bmp");
            LockBitmap lockT = new LockBitmap(terrain);
            LockBitmap lockH = new LockBitmap(heightmap);
            lockT.LockBits();
            lockH.LockBits();

            var tablePalette = new Dictionary<Color, int>();
            for (int i = 0; i < terrain.Palette.Entries.Length; i++)
            {
                if (!tablePalette.ContainsKey(terrain.Palette.Entries[i])) { tablePalette.Add(terrain.Palette.Entries[i], i); }
            }

            for (int y = 0; y < lockT.Height; y++)
            {
                for (int x = 0; x < lockT.Width; x++)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("At pixel (" + x + ", " + y + ")");
                    var c = lockT.GetPixel(x, y);
                    int indexIn = tablePalette.ContainsKey(c) ? tablePalette[lockT.GetPixel(x, y)] : 0;
                    int height = GetHeight((TerrainCategoriesEU3)indexIn);
                    lockH.SetPixel(x, y, Color.FromArgb(height, height, height));
                }
            }

            lockT.UnlockBits();
            lockH.UnlockBits();
            SaveImage(heightmap, "heightmap_new.bmp");
        }
        public static byte[] GetImageHash(Bitmap image)
        {
            //Convert image to a byte array.
            ImageConverter ic = new ImageConverter();
            byte[] btImage = new byte[1];
            btImage = (byte[])ic.ConvertTo(image, btImage.GetType());

            //Compute a hash of the image.
            SHA256Managed shaM = new SHA256Managed();
            return shaM.ComputeHash(btImage);
        }
    }
}
