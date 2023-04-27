using System;
using System.Collections.Generic;

namespace c_storemanagement
{
    public class Magaza
    {
        private List<Urun> Urunler;
        private SatisTemsilcisi SatisTemsilcisi;
        private int SonId;

        public Magaza(SatisTemsilcisi satisTemsilcisi)
        {
            Urunler = new List<Urun>();
            SatisTemsilcisi = satisTemsilcisi;
            SonId = 0;
        }

        public void UrunEkle(Urun urun)
        {
            urun.Id = SonId++;
            Urunler.Add(urun);
        }

        public Urun UrunSat(int id)
        {
            Urun urun = Urunler.Find(u => u.Id == id);
            if (urun != null)
            {
                Urunler.Remove(urun);
                SatisTemsilcisi.SatisMiktari++;
                return urun;
            }
            return null;
        }

        public bool UrunSil(int id)
        {
            Urun urun = Urunler.Find(u => u.Id == id);
            if (urun != null)
            {
                Urunler.Remove(urun);
                return true;
            }
            return false;
        }

        public Urun UrunBul(int id)
        {
            return Urunler.Find(u => u.Id == id);
        }
    }
}
