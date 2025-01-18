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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon Sayısı
            LblLocationCount.Text = db.Location.Count().ToString();
            #endregion

            #region Toplam Kapasite
            LblSumCapacity.Text = db.Location.Sum(x=>x.Capacity).ToString();
            #endregion

            #region Rehber Sayısı
            LblGuideCount.Text = db.Guide.Count().ToString();
            #endregion

            #region Ortalama Kapasite
            LblAvgCapacity.Text = db.Location.Average(x=>x.Capacity).ToString();
            #endregion

            #region Ortalama Tur Fiyatı
            LblAvgLocationPrice.Text = db.Location.Average(x => (decimal?)x.Price)?.ToString("0.00") + "₺";
            #endregion

            #region Eklenen Son Ülke
            int lastCountryId=db.Location.Max(x=>x.LocationId);
            LblLastCountryName.Text = db.Location.Where(x=>x.LocationId==lastCountryId).Select(y=>y.Country).FirstOrDefault();
            #endregion

            #region Kapadokya Tur Kapasitesi
            LblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            #endregion

            #region Türkiye Turları Ortalama Kapasite
            LlbTurkeyCapacityAvg.Text = db.Location.Where(X=>X.Country=="Türkiye").Average(y=>y.Capacity).ToString();
            #endregion

            #region Roma Gezi Rehberi
            var romeGuideId = db.Location.Where(x=>x.City=="Roma").Select(y=>y.GuideId).FirstOrDefault();
            LblRomeGuideName.Text = db.Guide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            #endregion

            #region En Yüksek Kapasiteli Tur

            var maxCapacity = db.Location.Max(x=>x.Capacity);
            LblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
            #endregion

            #region En Pahallı Tur

            var maxPrice = db.Location.Max(x => x.Price);
            LblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();
            #endregion

            #region Tur Sayısı
            var guideIdByName = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            LblACLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByName).Count().ToString();
            #endregion
        }
    }
}
