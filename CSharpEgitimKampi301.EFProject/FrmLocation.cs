using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
      
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var valeus = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }
            ).ToList();
            CmbGuide.DisplayMember = "FullName";
            CmbGuide.ValueMember = "GuideId";
            CmbGuide.DataSource = valeus;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(NumUpCapacity.Value.ToString());
            location.City = TxtCity.Text;
            location.Country = TxtCountry.Text;
            location.Price = decimal.Parse(TxtPrice.Text);
            location.DayNight = TxtDayNight.Text;
            location.GuideId = int.Parse(CmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi Başarlı");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi Başarlı");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight = TxtDayNight.Text;
            updatedValue.Price = decimal.Parse(TxtPrice.Text);
            updatedValue.Capacity=byte.Parse(NumUpCapacity.Value.ToString());
            updatedValue.City = TxtCity.Text;
            updatedValue.Country = TxtCountry.Text;
            updatedValue.GuideId = int.Parse(CmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi Başarlı");
        }
    }
}
