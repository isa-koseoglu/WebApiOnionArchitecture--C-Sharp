using HotelFinder.Bisuiness.Abstcract;
using HotelFinder.Bisuiness.ConCreate;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiKontrol
{
    public partial class Form1 : Form
    {
        private IHotelService _hotelService;
        public Form1()
        {
            InitializeComponent();
            _hotelService = new HotelManager();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Countxx = _hotelService.HotelGetAll().Count();
            List<Hotel> Content = new List<Hotel>();
            
                foreach (Hotel Hotel in _hotelService.HotelGetAll())
                {
                    Content.Add(Hotel);
                }
            
                
            for (int i = 0; i < Countxx; i++)
            {
                listBox1.Items.Add(Content[i].Name+" -- "+Content[i].City);
            }
        }
    }
}
