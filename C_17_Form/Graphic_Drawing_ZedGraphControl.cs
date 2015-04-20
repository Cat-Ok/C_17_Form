using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace C_17_Form
{
    public partial class Graphic_Drawing_ZedGraphControl : Form
    {
        public Graphic_Drawing_ZedGraphControl()
        {


            InitializeComponent();



            var chart = new Chart { Parent = this, Dock = DockStyle.Fill };
            chart.InterpolationStep = 0.2f;
            chart.MinX = -5.0f;
            chart.MaxX = 5.0f;
            chart.Function = (x) => (Math.Sqrt(x * x + 1) * Math.Exp(x));
            
        }

        private void Graphic_Drawing_ZedGraphControl_Load(object sender, EventArgs e)
        {

        }
    }


    public class Chart : Control
    {
        /// <summary>
        /// Отступы
        /// </summary>
        public int Indent { get; set; }

        public float MaxX { get; set; }
        public float MinX { get; set; }
        public float MaxY { get; set; }
        public float MinY { get; set; }

        /// <summary>
        /// Шаг сетки
        /// </summary>
        public float GridStep { get; set; }

        /// <summary>
        /// Шаг интерполирования
        /// </summary>
        public float InterpolationStep { get; set; }

        /// <summary>
        /// Отображаемая функция
        /// </summary>
        public Func<double, double> Function;

        public Chart()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Indent = 20;
            MinX = -5;
            MaxX = 5;
            MinY = -5;
            MaxY = 5;
            GridStep = 1;
            InterpolationStep = 0.01f;
        }

        /// <summary>
        /// Область внутри которой будет рисоваться график
        /// </summary>
        private Rectangle ChartArea
        {
            get
            {
                var rect = ClientRectangle;
                rect.Inflate(-Indent, -Indent);
                return rect;
            }

        }

        /// <summary>
        /// Преобразует виртуальные координаты в пикселы
        /// </summary>
        float YToPixels(float y)
        {
            return ChartArea.Height * (y - MinY) / (MaxY - MinY);
        }

        /// <summary>
        /// Преобразует виртуальные координаты в пикселы
        /// </summary>
        float XToPixels(float x)
        {
            return ChartArea.Width * (x - MinX) / (MaxX - MinX);
        }

        /// <summary>
        /// Отрисовка
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var rect = ChartArea;
            var gr = e.Graphics;

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            var center = new PointF(rect.Left + XToPixels(0), rect.Bottom - YToPixels(0));

            //рисуем сетку
            using (var font = new Font(Font.FontFamily, 8f))
            using (var pen = new Pen(Color.FromArgb(50, Color.Navy), 1))
            {
                for (var x = MinX; x <= MaxX; x += GridStep)
                {
                    var absX = rect.Left + XToPixels(x);
                    gr.DrawLine(pen, absX, rect.Bottom, absX, rect.Top);
                    gr.DrawString(x.ToString("0.0"), font, Brushes.Navy, absX - 7, center.Y + 5);
                }

                for (var y = MinY; y <= MaxY; y += GridStep)
                {
                    var absY = rect.Bottom - YToPixels(y);
                    gr.DrawLine(pen, rect.Left, absY, rect.Right + 5, absY);
                    gr.DrawString(y.ToString("0.0"), font, Brushes.Navy, center.X - 25, absY - 5);
                }
            }

            //рисуем оси
            using (var pen = new Pen(Color.Navy, 1))
            {
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                gr.DrawLine(pen, center.X, rect.Bottom, center.X, rect.Top - 10);
                gr.DrawLine(pen, rect.Left, center.Y, rect.Right + 7, center.Y);
            }

            //рисуем функцию
            if (Function != null)
                using (var pen = new Pen(Color.Red, 2))
                    for (var x = MinX; x < MaxX; x += InterpolationStep)
                    {
                        var y1 = (float)Function(x);
                        var y2 = (float)Function(x + InterpolationStep);
                        e.Graphics.DrawLine(pen, rect.Left + XToPixels(x), rect.Bottom - YToPixels(y1), rect.Left + XToPixels(x + InterpolationStep), rect.Bottom - YToPixels(y2));
                    }
        }
    }
}

