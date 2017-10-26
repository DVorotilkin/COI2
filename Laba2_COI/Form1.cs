using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba1_COI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //--
        #region Переменные

        int width, height;//Размеры изображения

        //------Для оригинального изображения
        Bitmap OriginalImage;
        byte[, ,] OriginalImageByte;

        //------Для изменённого изображения
        Bitmap AlteredImage;
        byte[, ,] AlteredImageByte;

        //-----Для сохранения оригинального изображения при добавлении шума
        Bitmap BackupImage;
        byte[, ,] BackupImageByte;
        
        int sigma, scale;//Сигама для фильтра и размер апертуры фильтра
        int k;//Количество соседей для фильтра

        bool FormsSuccessfullFlag = false;//Нажал ли пользователь "Применить" в дочерней форме
        bool IsNoiseImageByte = false;//Зашумлено ли изображение
        bool IsNoiseImage;//Отображено зашумлённое изображение или нет

        #endregion

        //--
        #region Работа меню программы

        //----Файл
        #region Меню "Файл"

        private void загрузитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть исходное изображение";
                    посмотретьИсходноеИзображениеToolStripMenuItem.Enabled = false;
                    IsNoiseImageByte = false;
                    OriginalImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                    EnabledMeny(true);
                    width = OriginalImage.Width;
                    height = OriginalImage.Height;
                    DownConsole.Text = "Изображение успешно загружено.";
                    OriginalImageByte = toBytes(OriginalImage);
                    pictureBox1.Image = OriginalImage;
                    pictureBox2.Image = null;
                    label1.Text = "Количество пикселей: " + (height * width).ToString();
                    OpenHaracteristicMenu(false);
                }
                catch (Exception openE)
                {
                    DownConsole.Text = "Невозможно загрузить изображение: " + openE.Message;
                }
            }
        }
        //------Пункт меню  загрузки изображений

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------Пункт меню выхода из программы

        #endregion

        //----Фильтрация
        #region Меню "Фильтрация"
        private void добавитьАддитивныйШумToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (IsNoiseImageByte)
            {
                OriginalImage = BackupImage;
                OriginalImageByte = BackupImageByte;
            }
            Noise N = new Noise();
            N.Owner = this;
            N.ShowDialog();
            if (FormsSuccessfullFlag)
            {
                BackupImage = (Bitmap)OriginalImage.Clone();
                OriginalImage = N.getNoiseImage();
                IsNoiseImage = true;
                pictureBox1.Image = OriginalImage;
                посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть исходное изображение";
                посмотретьИсходноеИзображениеToolStripMenuItem.Enabled = true;
                удалитьШумToolStripMenuItem.Enabled = true;
                IsNoiseImageByte = true;
            }
            FormsSuccessfullFlag = false;
            OpenHaracteristicMenu(false);
        }
        //------Пункт меню Добавить шум

        private void удалитьШумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginalImageByte = BackupImageByte;
            OriginalImage = BackupImage;
            pictureBox1.Image = OriginalImage;
            pictureBox2.Image = null;
            удалитьШумToolStripMenuItem.Enabled = false;
            посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть исходное изображение";
            посмотретьИсходноеИзображениеToolStripMenuItem.Enabled = false;
            IsNoiseImageByte = false;
            OpenHaracteristicMenu(false);
        }
        //------Пункт меню Удалить шум

        private void сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = SmoothingReverseGradient(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = SmoothingReverseGradient(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = SmoothingReverseGradient(OriginalImageByte, y, x, 2);
                }
            }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
            OpenHaracteristicMenu(true);
        }
        //------Пункт меню Сглаживание по обратному коэффициенту

        private void сигмафильтрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sigma_Filter SF = new Sigma_Filter();
            SF.Owner = this;
            SF.ShowDialog();
            if (FormsSuccessfullFlag)
            {
                AlteredImageByte = new byte[3, height, width];
                int shift = (scale - 1) / 2;
                for (int y = shift; y < height - shift; y++)
                    for (int x = shift; x < width - shift; x++)
                    {
                        AlteredImageByte[0, y, x] = Sigma(OriginalImageByte, y, x, 0, shift, OriginalImageByte[0, y, x]);
                        AlteredImageByte[1, y, x] = Sigma(OriginalImageByte, y, x, 1, shift, OriginalImageByte[1, y, x]);
                        AlteredImageByte[2, y, x] = Sigma(OriginalImageByte, y, x, 2, shift, OriginalImageByte[2, y, x]);
                    }
                FormsSuccessfullFlag = false;
                AlteredImage = toBitmap(AlteredImageByte);
                pictureBox2.Image = AlteredImage;
                OpenHaracteristicMenu(true);
            }
        }
        //------Пункт меню Сигма-фильтрация

        private void сглаживаниеМетодомКближайшихСоседейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sigma_Filter KNeighbors = new Sigma_Filter();
            KNeighbors.Text = "Метод К-ближайших соседей";
            KNeighbors.Owner = this;
            KNeighbors.checkKneighbors(true);
            KNeighbors.ShowDialog();
            if (FormsSuccessfullFlag)
            {
                AlteredImageByte = new byte[3, height, width];
                int shift = (scale - 1) / 2;
                for (int y = shift; y < height - shift; y++)
                    for (int x = shift; x < width - shift; x++)
                    {
                        AlteredImageByte[0, y, x] = K_Neighbors(OriginalImageByte, y, x, 0, shift);
                        AlteredImageByte[1, y, x] = K_Neighbors(OriginalImageByte, y, x, 1, shift);
                        AlteredImageByte[2, y, x] = K_Neighbors(OriginalImageByte, y, x, 2, shift);
                    }
                FormsSuccessfullFlag = false;
                AlteredImage = toBitmap(AlteredImageByte);
                pictureBox2.Image = AlteredImage;
                OpenHaracteristicMenu(true);
            }
        }
        //------Пункт меню Сглаживание методом К-ближайших соседей

        private void сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 2; y < height - 2; y++)
                for (int x = 2; x < width - 2; x++)
                {
                    AlteredImageByte[0, y, x] = Regions(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = Regions(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = Regions(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
            OpenHaracteristicMenu(true);
        }
        //------Пункт меню Сглаживание по наиболее однородной окрестности

        private void эффективностьМетодаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kriterii k = new Kriterii();
            k.Owner = this;
            k.Show();
        }
        //------Пункт меню Эффективность метода

        private void посмотретьИсходноеИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNoiseImage)
            {
                pictureBox1.Image = BackupImage;
                посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть зашумлённое изображение";
                IsNoiseImage = false;
            }
            else
            {
                pictureBox1.Image = OriginalImage;
                посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть исходное изображение";
                IsNoiseImage = true;
            }
        }
        //------Пункт меню Посмотреть исходное изображение

        #endregion

        #endregion

        #region Методы обработки изображений
        #region По обратному коэффициенту
        private byte SmoothingReverseGradient(byte[, ,] byteMass, int y, int x, int chennal)
        {
            byte pixel = 0;
            double[,] trident = Trident(byteMass, y, x, chennal);
            double[,] doubleW = DoubleW(trident);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    pixel += Convert.ToByte(doubleW[j, i] * byteMass[chennal, y + i - 1, x + j - 1]);
                }
            return pixel;
        }
        //------Метод возращающий значение канала пикселя фильтрования по обратному коэффиценту

        private double[,] DoubleW(double[,] trident)
        {
            double[,] res = new double[3, 3];
            double tridentSum = TridentSum(trident);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        res[j, i] = 0.5D;
                    }
                    else
                        res[j, i] = trident[j, i] / (2 * tridentSum);
                }
            return res;
        }
        //------Метод формирования массива значений W для конкретного канала пикселя

        private double[,] Trident(byte[, ,] byteMass, int y, int x, int chennal)
        {
            double[,] res = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (byteMass[chennal, y + i - 1, x + j - 1] == byteMass[chennal, y, x])
                        res[j, i] = 0.5D;
                    else
                        res[j, i] = 1.0D / Math.Abs(byteMass[chennal, y + i - 1, x + j - 1] - byteMass[chennal, y, x]);
                }
            return res;
        }
        //------Метод формирования массива значений Сигма для конкретного канала пикселя

        private double TridentSum(double[,] trident)
        {
            double sum = 0.0D;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    sum += trident[j, i];
            return sum;
        }
        //------Метод возвращающий сумму всех сигм для конкретного канала пикселя

        #endregion

        //----Сигма-фильтрация
        #region Сигма-фильтрация

        private byte Sigma(byte[, ,] byteMass, int y, int x, int chennal, int shift, byte value)
        {
            byte pixel = 0;
            int[,] sigmaU = new int[scale, scale];
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    sigmaU[j, i] = SigmaRules(value, byteMass[chennal, y + i - shift, x + j - shift]);
            int sigmaUsum = SigmaSum(sigmaU);
            if (sigmaUsum == 0)
                return 0;
            int cash = 0;
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    cash += byteMass[chennal, y + i - shift, x + j - shift] * sigmaU[j, i];
            pixel = toByte(cash / sigmaUsum);
            return pixel;

        }
        //------Метод возращающий значение канала пикселя Сигма-фильтрацией

        private int SigmaRules(byte CenterByte, byte LeftByte)
        {
            if (Math.Abs(LeftByte - CenterByte) <= sigma)
                return 1;
            else
                return 0;
        }
        //------Метод определяющий, входит ли значение пикселя в диапазон сигма

        private int SigmaSum(int[,] sigmaU)
        {
            int sum = 0;
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    sum += sigmaU[j, i];
            return sum;
        }
        //------Метод возвращает количество попавших в диапазон сигма пикселей

        public void setSigmaFilter(int scale, int sigma, int k)
        {
            this.scale = scale;
            this.sigma = sigma;
            this.k = k;
        }
        //------Метод передающий из дочерней формы параметры метода
        #endregion

        //----К-ближайших соседей
        #region К-ближайших соседей
        private byte K_Neighbors(byte[, ,] byteMass, int y, int x, int chennel, int shift)
        {
            byte value = getValue(byteMass, y, x, chennel, shift);

            return Sigma(byteMass, y, x, chennel, shift, value);
        }
        //------Метод возращающий значение канала пикселя методом К-ближайших соседей

        private byte getValue(byte[, ,] byteMass, int y, int x, int chennel, int shift)
        {
            List<Tuple<byte, int, int>> Neighbors = new List<Tuple<byte, int, int>>(k);
            for (int count = 0; count < k; count++)
            {
                Neighbors.Add(FindNeighbors(byteMass, y, x, chennel, shift, Neighbors));
            }
            int sum = 0;
            for (int count = 0; count < k; count++)
            {
                sum += Neighbors[count].Item1;
            }
            int value = sum / k;
            return toByte(value);
        }
        //------Метод возращающий значение, с которым производится сравнение в сигма-фильтрации

        private Tuple<byte, int, int> FindNeighbors(byte[, ,] byteMass, int y, int x, int chennel, int shift, List<Tuple<byte, int, int>> Neighbors)
        {
            Tuple<byte, int, int> neighbor = Tuple.Create((byte)0, 0, 0),
                cash = Tuple.Create((byte)0, 0, 0);
            byte min = 255;
            byte value;
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                {
                    if (!(y + i - shift == y && x + j - shift == x))
                    {
                        value = (byte)Math.Abs(byteMass[chennel, y + i - shift, x + j - shift] - byteMass[0, y, x]);
                        if (value <= min)
                        {
                            cash = Tuple.Create(byteMass[chennel, y + i - shift, x + j - shift], y + i - shift, x + j - shift);
                            if (!CheckTupleList(Neighbors, cash))
                            {
                                neighbor = cash;
                                min = value;
                            }
                        }
                    }
                }
            return neighbor;
        }
        //------Метод поиска К-ближайших соседей

        private bool CheckTupleList(List<Tuple<byte, int, int>> Neighbors, Tuple<byte, int, int> value)
        {
            if (Neighbors.Count() == 0)
                return false;
            for (int count = 0; count < Neighbors.Count(); count++)
            {
                if (Neighbors[count].Equals(value))
                    return true;
            }
            return false;
        }
        //------Метод определяющий, есть ли в массиве соседей входящая запись

        #endregion

        //----По однородныйм областям
        #region По однородныйм областям

        private byte Regions(byte[, ,] byteMass, int y, int x, int chennal)
        {
            int[] Vk = new int[9];
            for (int id = 0; id < 9; id++)
                Vk[id] = FindRegionVk(byteMass, y, x, chennal, id + 1);
            int minId = FindMinVkId(Vk);
            return toByte(SumPixels(byteMass, y, x, chennal, minId) / 9);
        }
        //------Метод возращающий значение канала пикселя методом однородных облостей

        private int FindRegionVk(byte[, ,] byteMass, int y, int x, int chennal, int id)
        {
            int thisVk = 0;
            int center_i = (int)((id - 1) / 3);
            int center_j = (int)(id % 3 - 1);
            if (center_j < 0)
                center_j = 2;
            int center_x = x + center_j - 1;
            int center_y = y + center_i - 1;
            for (int i = center_y - 1; i <= center_y + 1; i++)
                for (int j = center_x - 1; j <= center_x + 1; j++)
                {
                    if (!byteMass[chennal, i, j].Equals(byteMass[chennal, y, x]))
                        thisVk += Math.Abs(byteMass[chennal, i, j] - byteMass[chennal, y, x]);
                }
            return thisVk;
        }
        //------Метод возвращающий значение V(k) для конкретной области конкретного канала конкретного пикселя

        private int FindMinVkId(int[] Vk)
        {
            int minId = 5;
            int minVk = 255;
            for (int id = 0; id < 9; id++)
            {
                if (Vk[id] <= minVk)
                {
                    minId = id + 1;
                    minVk = Vk[id];
                }
            }
            return minId;
        }
        //------Метод определяющий в какой области минимальное значение V(k)

        private int SumPixels(byte[, ,] byteMass, int y, int x, int chennal, int id)
        {
            int center_i = (int)((id - 1) / 3);
            int center_j = (int)(id % 3 - 1);
            if (center_j < 0)
                center_j = 2;
            int sum = 0;
            int center_x = x + center_j - 1;
            int center_y = y + center_i - 1;
            for (int i = center_y - 1; i <= center_y + 1; i++)
                for (int j = center_x - 1; j <= center_x + 1; j++)
                {
                    sum += byteMass[chennal, i, j];
                }
            return sum;
        }
        //------Метод возвращающий сумму значений канала пикселей в области

        #endregion
        #endregion

        //--
        #region Специальные и служебные методы

        //----Методы get
        #region Методы get

        public int getHeight()
        {
            return height;
        }
        //------Метод возвращающий высоту изображения

        public int getWidth()
        {
            return width;
        }
        //------Метод возвращающий ширину изображения

        public byte[, ,] getOriginalImageByte()
        {
            return OriginalImageByte;
        }
        //------Метод возращающий массив байтов оригинального изображения

        public byte[, ,] getAlteredImageByte()
        {
            return AlteredImageByte;
        }
        //------Метод возвращающий массив байтов изменённого изображения

        public byte[, ,] getBackupImageByte()
        {
            return BackupImageByte;
        }
        //------Метод возвращающий массив байтов изображения в Бэкапе

        public Bitmap getOriginalImage()
        {
            return OriginalImage;
        }
        //------Метод возарщающий орагинальне изображение

        public bool getIsNoisedImageByte()
        {
            return IsNoiseImageByte;
        }
        //------Метод возращающий логическое значение является ли изображение зашумлённым

        #endregion

        //----Методы set
        #region Методы set

        public void setPictureBox2(byte[, ,] byteMass)
        {
            pictureBox2.Image = toBitmap(byteMass);
        }
        //------Метод заменющий пикчерБокс2 на приходящий массив байт

        public void setAlteredImageByte(byte[,,] byteMass)
        {
            AlteredImageByte = (byte[,,])byteMass.Clone();
        }
        //------Метод заменющий массив изменённого изображения на приходящий массив байт

        #endregion

        //----Методы изменения bool переменных
        #region Методы изменения bool переменных

        private void EnabledMeny(bool flag)
        {
            фильтрацияToolStripMenuItem.Enabled = flag;
        }
        //------Метод определяет активны ли меню обработки изображения

        public void isSeccessfullyForm(bool flag)
        {
            FormsSuccessfullFlag = flag;
        }
        //------Метод определяет, нажал ли пользователь кнопку "Применить" в дочерней форме

        private void OpenHaracteristicMenu(bool flag)
        {
            эффективностьМетодаToolStripMenuItem.Enabled = flag;
        }
        //------Метод определяет активен ли пункт меню "Эффективность метода"

        #endregion

        //----Методы конвертации данны
        #region Методы конвертации данны

        public byte[, ,] toBytes(Bitmap bmp)
        {
            byte[, ,] res = new byte[3, height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    Color color = bmp.GetPixel(x, y);
                    res[0, y, x] = color.R;
                    res[1, y, x] = color.G;
                    res[2, y, x] = color.B;
                }
            return res;
        }
        //------Метод конвертирует изображение в массив байт

        public Bitmap toBitmap(byte[, ,] byteMass)
        {
            Bitmap res = new Bitmap(width, height);
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    Color color = Color.FromArgb(byteMass[0, y, x],
                        byteMass[1, y, x],
                        byteMass[2, y, x]);
                    res.SetPixel(x, y, color);
                }
            return res;
        }
        //------Метод конвертирует массив байт в изображение

        public byte toByte(int pixel)
        {
            if (pixel <= 0)
                return 0;
            else if (pixel > 255)
                return 255;
            else
                return (byte)pixel;
        }
        //------Метод ковертирует значение типа int в значение типа byte

        #endregion

        //----Служебные методы
        #region Служебные методы

        public void ApplyNoise(byte[, ,] noiseImage)
        {
            BackupImageByte = OriginalImageByte;
            OriginalImageByte = noiseImage;
            pictureBox2.Image = null;
        }
        //------Метод применяет к изображению шум

        public int MultMatrix(int[,] firstMatrix, byte[,,] byteMass, int y, int x, int chennal, int scale)
        {
            int sum = 0;
            int shift = (scale - 1) / 2;
            for (int i = -shift; i < shift+1; i++)
                for (int j = -shift; j < shift+1; j++)
                {
                    sum += firstMatrix[i+shift, j+shift] * byteMass[chennal,y+i,x+j];
                }
            return sum;
        }
        //------Метод применения маски к участку изображения

        private int[,] RotateMatrix(int[,] Matrix)
        {
            int[,] NewMatrix = new int[3, 3];
            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                {
                    if (i == 0 && (j >= 0 && j < 2))
                        NewMatrix[i, j + 1] = Matrix[i, j];
                    else if (j == 2 && (i >= 0 && i < 2))
                        NewMatrix[i + 1, j] = Matrix[i, j];
                    else if (i == 2 && (j > 0 && j <= 2))
                        NewMatrix[i, j - 1] = Matrix[i, j];
                    else if (j == 0 && (i > 0 && i <= 2))
                        NewMatrix[i - 1, j] = Matrix[i, j];
                    else
                        NewMatrix[i, j] = Matrix[i, j];
                }
            return NewMatrix;
        }
        //------Метода поворачивает входящую матрицу на 45 градусов

        #endregion

        #endregion
          
    }
}