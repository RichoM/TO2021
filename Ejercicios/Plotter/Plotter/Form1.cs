using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Plotter.Plotting;

namespace Plotter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private World world = new World();

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeWorld();
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint,
                true);
        }

        private void InitializeWorld()
        {
            PlottingFunction function = new PlottingFunction();
            function.Position = new PointF(world.Width, 0);
            world.Add(function);            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            world.DrawOn(e.Graphics);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            ClientSize = new Size(world.Width, world.Height);
            world.Update();
            Refresh();
        }      
    }
}
